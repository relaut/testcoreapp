node('jenkins-slave') { //jenkins slave is the pod label from the Kubernetes plugin config
        def scmUrl = scm.getUserRemoteConfigs()[0].getUrl()
        echo "ScmUrl = ${scmUrl}"
        def projectName = "${scmUrl}".replaceAll('https://github.com/', '').replaceAll('.git', '')
        echo "ProjectName = ${projectName}"
        def imageTag = "${projectName}:${env.BUILD_NUMBER}".toLowerCase()
        echo "Image tag is ${imageTag}"
	sh 'env'
	echo ""
	echo ""
	echo ""
	echo ""
        container('jnlp-docker') {
                sh 'env'
		def password = "${env.JENKINS_URL}"
		echo "PASS = ${password}"
        }
}
