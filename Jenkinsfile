pipeline {
  agent {
    kubernetes {
      label 'slave-docker'
      defaultContainer 'jnlp'
      //yamlFile 'KubernetesPod.yaml'
    }
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
           def dockerTag = ""
           if( envType == "DEV"){
            sh 'echo this is a DEV build'
            sh 'echo $BUILD_TAG'
           dockerTag = env.BUILD_TAG
          }
          else {
            dockerTag = env.BUILD_ID
          }
          def customImage = docker.build("nadpereira/relautimages:$dockerTag")
           customImage.push()
         }
       }
     }
     
     stage("Testing") { 
       steps { 
        sh 'Performing some automated tests ....'
       }
       
       post { 
        success {
          echo "Testing completed Ok.  Proceeding to next step."
        }
        failure {
          echo "Tests failed ... aborting"
        }
      }
       
       stage("Push to Environment") { 
       steps { 
        echo "Pushing to environments"
        }
       }
       
     }
     
   }
}

/*
podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

  properties([
   parameters( [
        choice(choices: ['DEV', 'QA', 'PRODUCTION'], description: 'Which environment?', name: 'envType'),
        booleanParam(defaultValue: false, description: 'Build and Verify Only?', name: 'buildOnly'),
        string(defaultValue: "", description: 'Would you like to add a string?', name: 'info'),
    ])
   ])
  
  node('jenkins-build-agent') {
      
      stage('Get SCM')  {
        checkout scm
      }
    stage('Build Docker image') {
      container('jnlp-docker') {
        sh 'docker version'
        sh 'printenv'
        
        def dockerTag = ""
        
        if( envType == "DEV"){
          sh 'echo this is a DEV build'
          sh 'echo $BUILD_TAG'
          dockerTag = env.BUILD_TAG
        }
        else {
          dockerTag = env.BUILD_ID
        }
        
        def customImage = docker.build("nadpereira/relautimages:$dockerTag")
    //customImage.push()

    //customImage.push('latest')
              
              
        //sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:test1 .'
      }
    }
    
    //def list = ["new","old"]
    //    def inputRequest = list.collect  { string(defaultValue: "def", description: 'description', name: it)  }
    //    def myValue = input message: 'Enter Input', parameters: inputRequest
    
    stage ('Branch') {
        
      
      }
  }
}
*/
