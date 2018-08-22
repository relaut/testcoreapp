node('jenkins-slave') {
	container('jnlp-docker') {
		sh 'env.DOCKER_PASSWORD'
		def home = "${env.HOME}"
		echo "${env.HOME}"
		echo "${env.JENKINS_NAME}"
		echo "${env.DOCKER_PASSWORD}"
		echo "${env.DOCKER_USERNAME}"
		echo "home = ${home}"
	}
}
