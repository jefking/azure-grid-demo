--1. Create Group
az group create --name vademo --location westus2

--2. Create Event Grid Topic
az eventgrid topic create --name vanazure -l westus2 -g vademo

--3. Create Request Bin
https://requestb.in/

--4. Subscribe to Events
az eventgrid topic event-subscription create --name watching \
  --endpoint https://requestb.in/1ae891j1 \
  -g vademo \
  --topic-name vanazure

--Get endpoint
endpoint=$(az eventgrid topic show --name vanazure -g vademo --query "endpoint" --output tsv)

--Get Key
key=$(az eventgrid topic key list --name vanazure -g vademo --query "key1" --output tsv)

--Set Body
body=$(eval echo "'$(curl https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/event-grid/customevent.json)'")

--POST Message
curl -X POST -H "aeg-sas-key: $key" -d "$body" $endpoint

--5. Delete Resource Group
az group delete --name vademo