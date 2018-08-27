node('jenkins-slave') {
	container('jnlp-docker') {
		def scmUrl = scm.getUserRemoteConfigs()[0].getUrl()
		//def projectName = "${scmUrl}".replaceAll('https://github.com/', '').replaceAll('.git', '').replaceAll("${env.DOCKER_USERNAME}",'')
                def projectName = "${scmUrl}".tokenize('/').last().split("\\.")[0]
                echo "ProjectName = ${projectName}"

                def imageTag = "${projectName}:${env.BUILD_NUMBER}".toLowerCase()
                echo "Image tag is ${imageTag}"

		echo "*******************************************"
		//sh ''' docker login --username=$DOCKER_USERNAME --password=$DOCKER_PASSWORD '''
		echo "*******************************************"
		def docker_repo_name = sh 'printenv DOCKER_REPO_NAME'
	       // def cmd = "docker login --username=" + docker_user + " --password=" + docker_pwd
		//echo cmd
		//sh("printenv DOCKER_USERNAME")
		//sh("echo $DOCKER_USERNAME")
        /*        sh ("""
                """) */
		sh(''' docker version ''')
		checkout scm
		sh(''' docker login --username=$DOCKER_USERNAME --password=$DOCKER_PASSWORD ''')
//                def dockerTag  = "${docker_repo_name}/${imageTag}"
//                echo dockerTag
		sh(""" docker build -f Dockerfile -t \$DOCKER_REPO_NAME/$projectName:\$BUILD_NUMBER . """)
                   
		sh(""" docker push \$DOCKER_REPO_NAME/$projectName:\$BUILD_NUMBER """)
	}
}
