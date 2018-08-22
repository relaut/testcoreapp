pipeline {
	agent none
	stages {
		stage("Example") {
			agent {label 'jnlp-docker'}
			steps {
				echo "TEST"
				sh 'env'
			}
		}
	}
}
		
