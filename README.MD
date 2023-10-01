# Setup

Project can be setup via (1 -Docker compose 2- Visual Studio)

# Docker setup:

- navigate to src folder
- change project db connection according to requirement in API folder
- execute docker-compose up -d
- for db authetentication refere SA and username and password in docker-compose.yml

The entry point for this app starts with Shop.Api all other components are
sub project for the application.

# Visual Studio

- make sure to have .net sdk 6 installed in OS
- load the project in visual studio
- when loading is completed change the connection string for db
- run the project and accept the certificate.
- url https://localhost:44387/swagger/index.html

# URL

- Swagger: https://localhost:50561/swagger
- Authorized javascript engines are : localhost:3000

# Migration:

When project starts initaly it migrate all table and data
to target database in case of successfull authentication with sql server
altetnviaty following commands can be executed from api folder

- dotnet ef migrations add InitialCreate --startup-project src\Shop.Api\ --project src\Shop.Infrastructure
- dotnet ef database update --project src\Shop.Api

# React

- npm i and followed npm run
- The server can be done via base url which is located in constant.ts file
  and it will effect all only domain and port (baseurl)
- url: localhost:3000

# Core packages:

- API - .net core 6
- Node.js -> 18
- React -> 18
