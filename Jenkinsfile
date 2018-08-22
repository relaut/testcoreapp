pipeline {
	agent any 
	sh 'env'
	stages {
		stage('Build') {
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
