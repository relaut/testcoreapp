node('jenkins-slave') { //jenkins slave is the pod label from the Kubernetes plugin config
	environment {
		TEST = "test"
	}
        def scmUrl = scm.getUserRemoteConfigs()[0].getUrl()
        echo "ScmUrl = ${scmUrl}"
        def projectName = "${scmUrl}".replaceAll('https://github.com/', '').replaceAll('.git', '')
        echo "ProjectName = ${projectName}"
        def imageTag = "${projectName}:${env.BUILD_NUMBER}".toLowerCase()
        echo "Image tag is ${imageTag}"
	env.TEST_ENV="test"
	sh 'env'
	echo ""
	echo ""
	echo ""
	echo ""
	echo "TEST = $TEST"
        container('jnlp-docker') {
                sh 'env'
		sh 'printenv'
		echo "DOCKER_PASSWORD = ${env.DOCKER_PASSWORD}"
		echo "TEST = $TEST"
        }
}
