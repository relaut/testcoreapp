pipeline {
    agent {
        docker {
        label ‘docker-node’
        image ‘docker’
        //args ‘-v /tmp:/tmp -p 80:80’
        }
    }
    environment {
    //GIT_COMMITTER_NAME = ‘jenkins’
    }
    options {
        timeout(1, HOURS)
    }
    stages {
        stage(‘Build’) {
            steps {
            echo 'Building'
            docker.build("nadepereira/relautimages:${env.BUILD_ID}")    
        }
    }
    stage(‘Archive’) {
        when {
            branch ‘*/master’
        }
        steps {
           echo 'Archive step'
        }
        }
    }
 
}
