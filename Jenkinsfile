podTemplate(label: 'dockerPod', containers: [
    containerTemplate(name: 'docker', image: 'docker:latest', ttyEnabled: true, command: 'cat'),
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
        stage ('Branch') {
      
      input {
                message "Should we continue?"
                ok "Yes, we should."
                parameters {
                    string(name: 'PROD_DEPLOY', defaultValue: 'No', description: 'Perform Prod Deployment?')
                }
            }
      
            when {
                // Only say hello if a "greeting" is requested
                expression { PROD_DEPLOY == 'Yes' }
            }
            steps {
                echo "Performing Prod Deployment!"
            }
            
        }
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

