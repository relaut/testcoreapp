pipeline {
	agent any 
	stages {
		stage('Build') {
			steps {
				echo env.BUILD_NUMBER
				echo env.DOCKER_PASSWORD
				echo currentBuild.buildVariables
				println build.getEnvVars()
			}
		}
	}
}	
