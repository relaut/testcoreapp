node('jenkins-slave') {
	container('jnlp-docker') {
		def scmUrl = scm.getUserRemoteConfigs()[0].getUrl()
		def projectName = "${scmUrl}".replaceAll('https://github.com/', '').replaceAll('.git', '')
                echo "ProjectName = ${projectName}"

                def imageTag = "${projectName}:${env.BUILD_NUMBER}".toLowerCase()
                echo "Image tag is ${imageTag}"

		def docker_pwd = sh 'printenv DOCKER_PASSWORD'
		def docker_user = "sh 'echo $DOCKER_USERNAME'
		echo "username = ${docker_user}"
		def docker_repo_name = sh 'printenv DOCKER_REPO_NAME'
	        def cmd = "docker login --username=${docker_user} --password=${docker_pwd}"
		echo "Command = ${cmd}"
		sh("docker login --username=$DOCKER_USERNAME --password=$DOCKER_PASSWORD")
		sh("docker build -f Dockerfile -t ${imageTag} .")
		sh("docker push ${docker_repo_name}/${imageTag}")
	}
}
