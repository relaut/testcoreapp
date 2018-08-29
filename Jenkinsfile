pipeline {
  agent { label 'docker' }
  options {
    buildDiscarder(logRotator(numToKeepStr: '5'))
  }
  
  stages {
    
    stage('Who Am I') {
      steps {
        
        sh 'whoami'
      }
    }
    
    stage('Build') {
      steps {
        sh 'docker version'
        //sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:$.env.BRANCH_NAME-$env.BUILD_NUMBER .'
      }
    }
      
    stage('Publish') {
      when {
        branch 'master'
      }
      steps {
        withDockerRegistry([ credentialsId: "123", url: "" ]) {
          sh 'docker push nadpereira/relautimages'
        }
      }
    }
  }
}


/*pipeline {
    agent { dockerfile true }
    stages {
        stage('Build Test') {
            steps {
                sh 'docker version'
            }
        }
    }
}


pipeline {
    agent {
       docker {
         image 'nadpereira/jenkins-slave'
         args '-u root'
       }
    }
    stages {
        stage('Build') {
            steps {
                sh 'whoami'
                sh 'docker version'
            }
        }
    }
}
*/
