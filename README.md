# ACIConsoleAppTest
A demonstration of running a console app in an Azure Container Instance, while mounting Azure Files.

# Deploying into your own container registry
In the GitHub action, "build-and-deploy-container.yml", replace the CONTAINER_REGISTRY and CONTAINER_REGISTRY_USERNAME values with your own.  You'll also need to create a
secret called "CONTAINER_REGISTRY_PASSWORD".

# Creating and running the container
This container is meant to be run as a "Console App" that runs a single task and does not expose any ports.  To create and run the container for the first time:

`az container create --resource-group $ACI_PERS_RESOURCE_GROUP --name aci-counter --image $ACR_REGISTRY_HOST/aci-counter:latest  --azure-file-volume-account-name $ACI_PERS_STORAGE_ACCOUNT_NAME --azure-file-volume-account-key $STORAGE_KEY --azure-file-volume-share-name $ACI_PERS_SHARE_NAME --azure-file-volume-mount-path /var/log/aci --restart-policy Never --registry-username $ACR_REGISTRY_USERNAME --registry-password $ACR_REGISTRY_PASSWORD`

You'll need to fill in all of those variables.

When the container runs, it will write a timestamped file into the specified fileshare in Azure Files.  It will output ten lines of a counter, and then terminate.

To start the container after it has terminated, run:

`az container start --resource-group $ACI_PERS_RESOURCE_GROUP --name aci-counter`

