pipeline {
    agent {
        docker { image 'docker:latest' }
    }
    stages {
        stage('Test') {
            steps {
                script {
                    docker.Build();
                }
            }
        }
    }
}
