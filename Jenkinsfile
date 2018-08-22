node('jenkins-slave') {
	container('jnlp-docker') {
		sh 'printenv DOCKER_PASSWORD  > /var/out.txt'
		echo "${env.HOME}"
		echo "${env.JENKINS_NAME}"
		echo "${env.DOCKER_PASSWORD}"
		echo "${env.DOCKER_USERNAME}"
		echo "home = ${home}"
	}
}
