pipeline {
    agent none 
    stages {
	
	stage('Checkout') {
		steps {
		echo 'Inside Checkout ...'
		}
	}
        stage('Build') {
            agent { docker 'microsoft/dotnet:sdk' } 
            steps {
		    script {
                echo 'Hello!'
		docker.build("nadepereira/relautimages:${env.BUILD_ID}")
		    }
            }
        }
        stage('Archive') {
            steps {
                echo 'Archiving....'
                
            }
        }
    }
}
