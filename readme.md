# To Install	
1.  Install .Net Core 2.1.
2.  Install docker
3.  Run: docker run -d -p 27017:27017 --name mongodb bitnami/mongodb:latest

# To Start
1.  Run: dotnet restore
2.  Run: docker start mongodb
3.  Run: npm run start