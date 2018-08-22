node('jenkins-slave') {
	container('jnlp-docker') {
		sh 'env'
		def home = "${env.HOME}"
		echo "home = ${home}"
	}
}
