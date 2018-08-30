podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

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
      def returnValue = input message: 'Need some input', parameters: [string(defaultValue: '', description: '', name: 'Give me a value')]
            
        }
  }
}
