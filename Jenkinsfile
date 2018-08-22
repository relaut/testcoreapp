pipeline {
	agent any 
	stages {
		sh 'env'
		stage('Build') {
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
