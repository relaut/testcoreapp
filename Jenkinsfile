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
    choice(choices: ['dev', 'qa', 'production'], description: 'Which environment is this for?', name: 'envType')
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
        not { branch 'production' } 
        not { branch 'qa' }
      } 
      steps {
        container('kubectl') {
          //Service update
          sh("sed -i.bak 's#{{envType}}#${envType}#' ./k8s/services/testcoreappservice.yml")
          sh("sed -i.bak 's#{{namespace}}#${envType}#' ./k8s/services/testcoreappservice.yml")
          sh("sed -i.bak 's#{{name}}#${svcName}#' ./k8s/services/testcoreappservice.yml")
          
          //Deployment update - 
          sh("sed -i.bak 's#{{name}}#${svcName}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{app}}#${appName}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{image}}#nadpereira/relautimages:${dockerTag}#' ./k8s/dev/*.yml")
          sh("sed -i.bak 's#{{envType}}#${envType}#' ./k8s/dev/*.yml")
          
          //verify 
          sh("cat ./k8s/services/testcoreappservice.yml")
          sh("cat ./k8s/dev/devdeployment.yml")
          
          //Todo - create ingress (and apply)
          
          sh("kubectl --namespace=${envType} apply -f k8s/services/")
          sh("kubectl --namespace=${envType} apply -f k8s/dev/")
          echo "show endpoint HERE"
        }
      }     
    }
     
   } //Stages
}//Pipeline
