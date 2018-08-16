node {
	stage 'Checkout'
	stage 'Build' {
		def customImage = docker.build("nadepereira/relautimages", "Dockerfile")
	}
        stage 'Archive'
}
