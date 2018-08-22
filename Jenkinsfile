pipeline {
	stages {
		stage('Build') {
			agent { node {label 'jnlp-docker'} }
			sh 'env'
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
