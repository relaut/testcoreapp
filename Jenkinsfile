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
                sh 'docker build image-name:test'
            }
        }
    }
}
