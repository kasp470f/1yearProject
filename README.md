# Første års projekt
*Made by [Kasper](https://github.com/kasp470f) and [Martin](https://github.com/mathex83)*

Dette her er vores første års projekt. Vi skal lave en opgave der handler om at indrapportere en virksomheds affald.

### Brug af applikation
Du kan gøre brug af denne applikation ved at ændre i app.config's connection string. Dette vil lade dig ændre i hvad database som du bliver tilknyttet.

Husk at gøre brug af CreateDb.sql for at let oprette databasen.
#### Lokal database
``` xaml
<connectionStrings>
  <add name="connection" providerName="System.Data.SqlClient" connectionString="Server=SERVER ADDRESS HERE;Initial Catalog=FoxtrotTrash;Trusted_Connection=True;" />
</connectionStrings>
```

#### Standard Connection (ikke lokal)
``` xaml
<connectionStrings>
  <add name="connection" providerName="System.Data.SqlClient" connectionString="Server=SERVER ADDRESS HERE;Initial Catalog=FoxtrotTrash;Persist Security Info=False;User ID=USERNAME HERE;Password=PASSWORD HERE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" />
</connectionStrings>
```
