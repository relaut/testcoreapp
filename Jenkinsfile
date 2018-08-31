
podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

  properties([
   parameters( [
        choice(choices: ['DEV', 'QA', 'PRODUCTION'], description: 'Which environment?', name: 'envType'),
        booleanParam(defaultValue: false, description: 'Build and Verify Only?', name: 'buildOnly'),
        string(defaultValue: "", description: 'Would you like to add a string?', name: 'info'),
    ])
   ])
  
  node('jenkins-build-agent') {
      
      stage('Get SCM')  {
        checkout scm
      }
    stage('Build Docker image') {
      container('jnlp-docker') {
        sh 'docker version'
        sh 'printenv'
        
        def dockerTag = ""
        
        if( envType == "DEV"){
          sh 'echo this is a DEV build'
          sh 'echo $BUILD_TAG'
          dockerTag = env.BUILD_TAG
        }
        else {
          dockerTag = env.BUILD_ID
        }
        
        def customImage = docker.build("nadpereira/relautimages:${env.BUILD_ID}")
    //customImage.push()

    //customImage.push('latest')
              
              
        //sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:test1 .'
      }
    }
    
    //def list = ["new","old"]
    //    def inputRequest = list.collect  { string(defaultValue: "def", description: 'description', name: it)  }
    //    def myValue = input message: 'Enter Input', parameters: inputRequest
    
    stage ('Branch') {
        
      
      }
  }
}
