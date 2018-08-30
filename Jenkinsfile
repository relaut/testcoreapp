podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

  //def image = "jenkins/jnlp-slave"
  
  node('jenkins-build-agent') {
      
      stage('Get SCM')  {
        checkout scm
      }
    stage('Build Docker image') {
      container('jnlp-docker') {
        sh 'docker version'
        sh '$env'
        sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:test1 .'
      }
    }
    stage ('Branch') {

      input {
                message "Should we continue?"
                ok "Yes, we should."
                parameters {
                    string(name: 'PROD_DEPLOY', defaultValue: 'No', description: 'Perform Prod Deployment?')
                }
            }
            when {
                expression { PROD_DEPLOY == 'Yes' }
            }
            steps {
                echo "Performing Prod Deployment!"
            }

        }
  }
}
