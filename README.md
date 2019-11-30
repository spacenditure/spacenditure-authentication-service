# Spacenditure Authentication Service

This Microservice main purpose is to authenticate user to use all other api's of **Spacenditure**.

This entity api is build on `dotnet core 3.0` and user `MySQL` as its database to store users information.

### Steps to run this locally
In order to run this service on local system, Add this property in `apppsetting.json`

```json
  "ConnectionStrings": {
    "UserDetailDbContext": "server=mysql;database=database;user=username;password=password"
  }
```
Later on you might require to update your database with the defined model.
To do than you can make use of `dotnet-ef`.

```bash
$ dotnet ef migrations add CreateUserDetailDb
```

After succeeded, run following to get your server started.

```bash
$ dotnet restore
Restore completed in 16.1 ms for /spacenditure-authentication-service/SpacenditureAuthentication.csproj.

$ dotnet run
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.

```

> Note: Make sure you have `dotnet core 3.0` installed in your system
