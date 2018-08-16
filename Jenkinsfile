node {
	stage 'Checkout'
	stage 'Build' {
		steps {
		def customImage = docker.build("nadepereira/relautimages:${env.BUILD_ID}")
		}
	}
        stage 'Archive'
}
