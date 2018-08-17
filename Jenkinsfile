podTemplate(label: 'dockerPod', containers: [
    containerTemplate(name: 'docker', image: 'docker', ttyEnabled: true, command: 'cat'),
    containerTemplate(name: 'kubectl', image: 'lachlanevenson/k8s-kubectl:v1.7.3', command: 'cat', ttyEnabled: true)
  ],
  volumes: [
    hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock'),
  ]) 
{
    node('dockerPod') {
    
    stage('Checkout SCM') {
        checkout scm
     }
        stage('Build Docker Image') {
        container('docker') {
            docker.build("nadepereira/relautimages:${env.BUILD_ID}")
            }
        }
     }
    stage('Publish Container') {
        echo 'PUBLISHING'
     }
}

