node('jenkins-slave') {
	container('jnlp-docker') {
		sh 'env'
		def home = "${env.HOME}"
		echo "${env.HOME}"
		echo "${env.JENKINS_NAME}"
		echo "home = ${home}"
	}
}
