node {
	stage 'Checkout'
	stage 'Build' {
		def customImage = docker.build("nadepereira/relautimages:${env.BUILD_ID}")
	}
        stage 'Archive'
}
