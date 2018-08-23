node('jenkins-slave') {
	container('jnlp-docker') {
		def pwd = sh 'printenv DOCKER_PASSWORD'
		echo "${pwd}"	
		sh 'printenv DOCKER_PASSWORD  > /var/out.txt'
		sh 'echo DOCKER_PASSWORD'
	}
}
