podTemplate(label: 'dockerPod', containers: [
    containerTemplate(name: 'docker', image: 'docker:latest', ttyEnabled: true, command: 'cat'),
    containerTemplate(name: 'kubectl', image: 'lachlanevenson/k8s-kubectl:v1.7.3', command: 'cat', ttyEnabled: true)
  ],
  volumes: [
    hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock'),
  ]) 
{
    def userInput
    
    node('dockerPod') {
    
     stage('Verify Step') {
        timeout(time: 1, unit: 'MINUTES') {
        input message: "Should we continue?"
        }
     }
    
     //just an example ... pull requests MAY make more sense to use   
     stage('Build') {
        userInput = input(
        id: 'Proceed1', message: 'Build for Production?', parameters: [
        [$class: 'BooleanParameterDefinition', defaultValue: true, description: '', name: 'Build for Production']
        ])
         
         when { userInput }
    steps {
        echo 'I execute on non-master branches.'
    }
         
         
     }
      
        
    stage('Checkout SCM') {
        checkout scm
     }
        if (userInput){
        stage('Build Image for Prod') {
        container('docker') {
            docker.build("nadepereira/relautimages:${env.BUILD_ID}")
            //sh("docker build -f Dockerfile -t test .")
            }
        }
        }}
    
    stage('Publish Container') {
        echo 'PUBLISHING'
     }
}
