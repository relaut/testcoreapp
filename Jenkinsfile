node('jenkins-slave') {
	def pwd = sh 'printenv DOCKER_PASSWORD'
	echo "${pwd}"	
	container('jnlp-docker') {
		sh 'printenv DOCKER_PASSWORD  > /var/out.txt'
		sh 'echo DOCKER_PASSWORD'
	}
}
