//parameters {
//        string(defaultValue: "", description: 'Would you like to add a string?', name: 'info')
//        choice(choices: ['DEV', 'QA', 'PRODUCTION'], description: 'Which environment?', name: 'region')
//        booleanParam(defaultValue: false, description: 'Build and Verify Only?', name: 'buildOnly')
//  }

podTemplate(label: 'jenkins-build-agent',
  containers: [containerTemplate(name: 'jnlp-docker', image: 'nadpereira/jenkins-slave:latest', ttyEnabled: true, command: 'cat')],
  volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
  ) {

  
  node() { 
  properties([
     parameters([
       booleanParam(
         defaultValue: false,
         description: 'isFoo should be false x',
         name: 'isFoo'
       ),
       booleanParam(
         defaultValue: true,
         description: 'isBar should be true x',
         name: 'isBar'
       ),
     ])
   ])
  }
  
  node('jenkins-build-agent') {
      
      stage('Get SCM')  {
        checkout scm
      }
    stage('Build Docker image') {
      container('jnlp-docker') {
        sh 'docker version'
        sh 'printenv'
        def customImage = docker.build("nadpereira/relautimages:${env.BUILD_ID}")
    //customImage.push()

    //customImage.push('latest')
              
              
        //sh 'docker build -f "Dockerfile" -t nadpereira/relautimages:test1 .'
      }
    }
    
    def list = ["new","old"]
        def inputRequest = list.collect  { string(defaultValue: "def", description: 'description', name: it)  }
        def myValue = input message: 'Enter Input', parameters: inputRequest
    
    stage ('Branch') {
        
      
      }
  }
}
