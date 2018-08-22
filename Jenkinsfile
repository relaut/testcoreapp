pipeline {
	agent any 
	stages {
		stage('Build') {
			steps {
				echo env.BUILD_NUMBER
				echo env.DOCKER_PASSWORD
				sh 'env'
				echo currentBuild
			}
		}
	}
}	
