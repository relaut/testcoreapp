parameters{
	DOCKER_PASSWORD="${DOCKER_PASSWORD}"
}


node('jenkins-slave') { //jenkins slave is the pod label from the Kubernetes plugin config
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
        container('jnlp-docker') {
                sh 'env'
		sh 'printenv'
		echo "DOCKER_PASSWORD = ${DOCKER_PASSWORD}"
        }
}
