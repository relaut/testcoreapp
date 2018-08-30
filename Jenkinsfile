podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

  def image = "jenkins/jnlp-slave"
  node('jnlp-docker') {
    stage('Build Docker image') {
      git 'https://github.com/jenkinsci/docker-jnlp-slave.git'
      container('docker') {
        sh "docker build -t ${image} ."
      }
    }
  }
}

/*
pipeline {
  agent { label 'docker' }
  options {
    buildDiscarder(logRotator(numToKeepStr: '5'))
  }
  
  stages {
    
    stage('Who Am I') {
      steps {
        
        sh 'whoami'
      }
    }
    
    stage('Build') {
      steps {
        sh 'pwd'
        sh 'ls /usr/bin'
        sh 'hostname'
        //sh '/usr/bin/docker version'
        //sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:test1 .'
      }
    }
      
    stage('Publish') {
      when {
        branch 'master'
      }
      steps {
        withDockerRegistry([ credentialsId: "123", url: "" ]) {
          sh 'docker push nadpereira/relautimages'
        }
      }
    }
  }
}


pipeline {
    agent { dockerfile true }
    stages {
        stage('Build Test') {
            steps {
                sh 'notreal version'
            }
        }
    }
}


pipeline {
    agent {
       docker {
         image 'nadpereira/jenkins-slave'
         args '-u root'
       }
    }
    stages {
        stage('Build') {
            steps {
                sh 'whoami'
                sh 'docker version'
            }
        }
    }
}
*/
