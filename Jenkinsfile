pipeline {
	stages {
		stage('Build') {
			docker {label 'jnlp-docker'}
			sh 'env'
			steps {
				echo env.BUILD_NUMBER
			}
		}
	}
}	
