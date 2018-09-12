def  appName = 'testcoreapp'
def  svcName = "${appName}-${env.BRANCH_NAME}"

pipeline {
  agent {
    kubernetes {
      label 'slave-docker'
      defaultContainer 'jnlp'
      
    }
  }
  
  environment {
    registry = 'nadpereira/relautimages'
    registryCredential = 'dockerhub'
    customImage = ''
    dockerTag = ''
  }
  
  parameters {
    choice(choices: ['dev', 'qa', 'production', 'canary'], description: 'Which environment is this for?', name: 'envType')
    booleanParam(defaultValue: false, description: 'Build and Verify Only?', name: 'buildOnly')
    string(defaultValue: "", description: 'Would you like to add a string?', name: 'info')
  }
  
   stages {
   
    // At least one stage is required.
    stage("Environment Info") {
      // Every stage must have a steps block containing at least one step.
      steps {
        sh 'docker version'
        sh 'printenv'
      }
      // Post can be used both on individual stages and for the entire build.
      post { 
        success {
          echo "Only when we haven't failed running the first stage"
        }
        failure {
          echo "Only when we fail running the first stage."
        }
      }
    }
     
     stage("Build"){
       steps {
         sh("sed -i.bak 's#{{buildVersion}}#${env.BUILD_ID}#' ./Views/Home/Index.cshtml")
         script {
          
          if( envType == "dev"){
            sh 'echo this is a DEV build'
            sh 'echo $BUILD_TAG'
           dockerTag = env.BUILD_TAG
          } //if
          else {
            dockerTag = env.BUILD_ID
          } //else
          customImage = docker.build("nadpereira/relautimages:$dockerTag")
          
          } //script
         } // steps
       } //stage
     
     
     stage("Testing") { 
       steps { 
        sh 'pwd'
       }
       
       post { 
        success {
          echo "Testing completed Ok.  Proceeding to next step."
        }
        failure {
          echo "Tests failed ... aborting"
        }
       }
     }
   
     stage("Push to DockerHub") { 
       steps { 
         script {
           docker.withRegistry( 'https://registry.hub.docker.com', registryCredential ) {
            customImage.push()
        }
         }
       }
      }
      
     
     stage("Deployment Environment Initialize") { 
       when { 
        expression { envType != 'canary' }
      }
       steps { 
         container('kubectl'){
           sh("kubectl version")
           sh("kubectl get ns $envType || kubectl create ns $envType")
           sh("pwd")
           sh("ls")
         }
       }
      }
      
     stage('Deploy Dev') {
      // Developer Branches
      when { 
        expression { envType == 'dev' }
      } 
      steps {
        container('kubectl') {
          //Service update
          sh("sed -i.bak 's#{{envType}}#${envType}#' ./k8s/services/testcoreappservice.yml")
          sh("sed -i.bak 's#{{namespace}}#${envType}#' ./k8s/services/testcoreappservice.yml")
          sh("sed -i.bak 's#{{name}}#${svcName}#' ./k8s/services/testcoreappservice.yml")
          sh("sed -i.bak 's#{{app}}#${svcName}#' ./k8s/services/testcoreappservice.yml")
          
          //Deployment update
          sh("sed -i.bak 's#{{name}}#${svcName}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{app}}#${appName}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{image}}#nadpereira/relautimages:${dockerTag}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{envType}}#${envType}#' ./k8s/dev/*.yml")
          
          //Ingress update
          sh("sed -i.bak 's#{{name}}#${svcName}#' ./k8s/ingress/*.yml")
          sh("sed -i.bak 's#{{serviceName}}#${svcName}#' ./k8s/ingress/*.yml")
          sh("sed -i.bak 's#{{hostPath}}#${appName}.${env.BRANCH_NAME}.${envType}.resistance.mnstr.io#' ./k8s/ingress/*.yml")
          
          
          //verify 
          sh("cat ./k8s/services/testcoreappservice.yml")
          sh("cat ./k8s/dev/devdeployment.yml")
          sh("cat ./k8s/ingress/devingress.yml")
          
          sh("kubectl --namespace=${envType} apply -f k8s/services/")
          sh("kubectl --namespace=${envType} apply -f k8s/dev/")
          sh("kubectl --namespace=${envType} apply -f k8s/ingress/")
          echo "show endpoint HERE"
        }
      }     
    }//Deploy Dev
     
    
     stage('Deploy Production') {
      // Developer Branches
      when { 
        expression { envType == 'production' }
      }
      steps {
        container('kubectl') {
          
          //Deployment update
          sh("sed -i.bak 's#{{image}}#nadpereira/relautimages:${dockerTag}#' ./k8s/production/*.yml")
          //prod will be a static configuration
          sh("kubectl --namespace=${envType} apply -f k8s/production/")
          sh("kubectl --namespace=${envType} apply -f k8s/ingress/prodingress.yml")
          
        }
      }     
    } 
     
     
    stage('Deploy Canary') {
      // Developer Branches
      when { 
        expression { envType == 'canary' }
      }
      steps {
        container('kubectl') {
         
          //Deployment update
          sh("sed -i.bak 's#{{image}}#nadpereira/relautimages:${dockerTag}#' ./k8s/canary/canarydeploy.yml")
          
          //verify 
          sh("cat ./k8s/canary/canaryservice.yml")
          sh("cat ./k8s/canary/canarydeploy.yml")
          sh("cat ./k8s/ingress/canaryingress.yml")
          
          sh("kubectl --namespace=production apply -f k8s/canary/canaryservice.yml")
          sh("kubectl --namespace=production apply -f k8s/canary/canarydeploy.yml")
          sh("kubectl --namespace=production apply -f k8s/ingress/canaryingress.yml")
          
          echo "Canary deployed to canary testing route only.  When ready, continue to split traffic for canary test."
          input("Ready to proceed to split traffic 3 to 1?")
          
          kc patch service testcoreapp --type='json' -p='[{"op":"add", "path":"/spec/selector", "value": {"app":"testcoreapp","env":"production"} }]' -n production
          sh("kubectl patch service testcoreapp --type='json' -p='[{"op":"add", "path":"/spec/selector", "value": {"app":"testcoreapp","env":"production"} }]' -n production")
          
          echo "Canary nodes are now taking 25% of traffic.  Continue to the next step to update the Prod deployment."
          input("Ready to proceed with updating the Prod deployment to the ?")
          sh("sed -i.bak 's#{{image}}#nadpereira/relautimages:${dockerTag}#' ./k8s/production/*.yml")
          //prod will be a static configuration
          sh("kubectl --namespace=production apply -f k8s/production/")
          
          echo "Prod deployment has been updated.  Continue with destroying the Canary?"
          input("Ready to proceed with destroying Canary deployment?")
          sh("kubectl --namespace=production delete deployment ${appName}")
          
          echo "The canary is dead ... poor canary :("
        }
      }     
    }
     
     
   } //Stages
}//Pipeline
