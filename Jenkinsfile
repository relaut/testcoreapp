pipeline {
	stages {
		stage('Build') {
			agent { docker {label 'jnlp-docker'} }
			sh 'env'
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
