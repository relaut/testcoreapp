
node {
  def branchVersion = ""

  stage ('Checkout') {
    // checkout repository
    checkout scm

    // checkout input branch 
    sh "git checkout ${caller.env.BRANCH_NAME}"
  }

    agent none 
    stages {
	
        stage('Build') {
            //agent { docker 'microsoft/dotnet:sdk' } 
            steps {
		    script {
                echo 'Hello!'
		docker.build("nadepereira/relautimages:${env.BUILD_ID}")
		    }
            }
        }
        stage('Archive') {
            steps {
                echo 'Archiving....'
                
            }
        }
    }

