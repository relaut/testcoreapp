pipeline {
    agent {
       docker {
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
