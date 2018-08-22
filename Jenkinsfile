node('jenkins-slave') {
	container('jnlp-docker') {
		echo "'some data' >> ./out.txt"
		echo "${env.HOME}"
		echo "${env.JENKINS_NAME}"
		echo "${env.DOCKER_PASSWORD}"
		echo "${env.DOCKER_USERNAME}"
		echo "home = ${home}"
	}
}
