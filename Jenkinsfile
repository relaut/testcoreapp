pipeline {
    agent {
       docker {
         image 'maven:3-alpine'
         args '-u root -v /root/.m2:/root/.m2 -v /var/run/docker.sock:/var/run/docker.sock'
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
