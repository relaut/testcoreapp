pipeline {
	agent none
	stages {
		stage('Build') {
			agent { node {label 'jnlp-docker'} }
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
