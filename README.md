# ASP.NET Course
This project was developed during the ASP.NET Course online class

# SQL Database

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=123Mud@r' -p 1401:1433 -d --name=sqlserverdb mcr.microsoft.com/mssql/server:2019-latest
```

# Running project using dotnet cli

```
dotnet build
dotnet run --project OrderService.Services.API
```
