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
     stage('Build for Prod') {
        userInput = input(
        id: 'Proceed1', message: 'Was this successful?', parameters: [
        [$class: 'BooleanParameterDefinition', defaultValue: true, description: '', name: 'Please confirm you agree with this']
        ])
     }
      
        
    stage('Checkout SCM') {
        checkout scm
     }
        stage('Build Docker Image') {
        container('docker') {
            docker.build("nadepereira/relautimages:${env.BUILD_ID}")
            //sh("docker build -f Dockerfile -t test .")
            }
        }
     }
    stage('Publish Container') {
        echo 'PUBLISHING'
     }
}
