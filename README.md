## Setting the connection string to secret manager
```powershell
$sa_password = "[december29]"
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DbConnection" "Server=127.0.0.1;Port=5432;User Id=postgres;Password=december29;Database=CarRental;Pooling=true;CommandTimeout=120;Timeout=30"
 dotnet user-secrets list
```

# Creating a migration
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
dotnet ef database update //translate migration to sql commands