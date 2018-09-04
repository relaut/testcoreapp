pipeline {
  agent {
    kubernetes {
      label 'slave-docker'
      defaultContainer 'jnlp'
      yaml = """
apiVersion: v1
kind: Pod
metadata:
  labels:
    some-label: test-app
spec:
  containers:
  - name: kubectl
    image: lachlanevenson/k8s-kubectl:latest
    imagePullPolicy: Always
    command:
    - cat
    tty: true
"""
    }
  }
  
  environment {
    registry = 'nadpereira/relautimages'
    registryCredential = 'dockerhub'
    customImage = ''
    dockerTag = ''
  }
  
  parameters {
    choice(choices: ['DEV', 'QA', 'PRODUCTION'], description: 'Which environment is this for?', name: 'envType')
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
          
          if( envType == "DEV"){
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
      
     
     stage("Deploy to Environments") { 
       steps { 
         container('kubectl'){
         sh("kubectl version")
         }
       }
      }
      
     
     
   } //Stages
}//Pipeline
