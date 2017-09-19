--1. Create Group
az group create --name vademo --location westus2

--2. Create Event Grid Topic
az eventgrid topic create --name vanazure -l westus2 -g vademo

--3. Create Request Bin
https://requestb.in/

--4. Subscribe to Events
az eventgrid topic event-subscription create --name watching \
  --endpoint https://requestb.in/1byifed1 \
  -g vademo \
  --topic-name vanazure

--5. Delete Resource Group
az group delete --name vademo