--Create Group
az group create --name vademo --location westus2

--Create Event Grid Topic
az eventgrid topic create --name vanazure -l westus2 -g vademo

--Create Request Bin
https://requestb.in/

--Subscribe to Events
az eventgrid topic event-subscription create --name watching \
  --endpoint https://requestb.in/1luyzot1 \
  -g vademo \
  --topic-name vanazure

  --Delete Resource Group
  az group delete -n vademo