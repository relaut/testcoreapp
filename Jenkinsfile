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
*/

pipeline {
    agent {
       docker {
         image 'nadpereira/jenkins-slave'
         //args '-u root'
       }
    }
    stages {
        stage('Build') {
            steps {
                sh 'docker version'
            }
        }
    }
}
