HTTP API for dashboard platform.

# run in all projects
dotnet build

# then run http server
dotnet run -p .\Sota.Dashboard.Http\Sota.Dashboard.Http.csproj --urls http://0.0.0.0:5000

# start development server
# on http://localhost:5000/api/v1/entity/1455662
dotnet run watch -p .\Sota.Dashboard.Http\Sota.Dashboard.Http.csproj

# to have it in LAN by http://192.168.3.102:5000/api/v1/entity/1455662
dotnet run --urls http://0.0.0.0:5000
dotnet watch run --urls http://0.0.0.0:5000
dotnet run watch -p .\Sota.Dashboard.Http\Sota.Dashboard.Http.csproj --urls http://0.0.0.0:5000

# build docker image
docker build -t dashboard-server:1 .     

# run the image in container
docker run --name dashboard-server -it -p 5000:80 dashboard-server:1
