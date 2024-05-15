$userInput = Read-Host "Type 1 for creation and 2 for deletion"
if($userInput -eq 1)
{
    #general
    kubectl create namespace netbank
    kubectl apply -f GeralSecrets.yaml -n netbank
    kubectl apply -f SqlServer.yaml -n netbank
    kubectl apply -f ElasticSearch.yaml
    kubectl apply -f Kibana.yaml
    kubectl apply -f Fluentd.yaml


    # netbank users
    kubectl create namespace netbankusers
    kubectl apply -f GeralSecrets.yaml -n netbankusers
    cd ./NetBank.Users
    kubectl apply -f UsersSecrets.yaml -n netbankusers

    cd ./NetBank.Users.API
    dotnet tool install --global dotnet-ef
    dotnet ef database update

    cd..

    docker build . -t netbankuser
    kubectl apply -f NetBankUsers.yaml -n netbankusers

    cd..
}else
{
    kubectl delete namespace netbankusers
    kubectl delete namespace netbank
    kubectl delete -f ElasticSearch.yaml
    kubectl delete -f Kibana.yaml
    kubectl delete -f Fluentd.yaml
}

