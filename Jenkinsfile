node('jenkins-slave') {
	container('jnlp-docker') {
		def projectname = "${scmurl}".replaceall('https://github.com/', '').replaceall('.git', '')
                echo "ProjectName = ${projectName}"

                def imageTag = "${projectName}:${env.BUILD_NUMBER}".toLowerCase()
                echo "Image tag is ${imageTag}"

		def docker_pwd = sh 'printenv DOCKER_PASSWORD'
		def docker_user = sh 'printenv DOCKER_USERNAME'
		def docker_repo_name = sh 'printenv DOCKER_REPO_NAME'
		
		sh("docker login --username=$DOCKER_USERNAME --password=DOCKER_PASSWORD")
		sh("docker build -f Dockerfile -t ${imageTag} .")
		sh("docker push ${imageTag}")
	}
}
