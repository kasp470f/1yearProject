# Første års projekt
*Made by [Kasper](https://github.com/kasp470f) and [Martin](https://github.com/mathex83)*

Dette her er vores første års projekt. Vi skal lave en opgave der handler om at indrapportere en virksomheds affald.

### Brug af applikation
Du kan gøre brug af denne applikation ved at ændre i app.config's connection string. Dette vil lade dig ændre i hvad database som du bliver tilknyttet.

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


CreateDb.sql 
- Kan bruges til at oprette den tomme database.

RestoreDb.sql
- Kan benyttes til at indlæse vores test-database med ca. 3800 poster
- Husk at ændre mappenavnet i query’en så det passer med den mappe du har gemt vores projekt i.
- Login i MS SQL Server Management Studio:

![sql](https://user-images.githubusercontent.com/55143058/120923842-f0c6f500-c6d0-11eb-9bd7-cb751e537dda.png)

Hvis du har en lokal database-server på din computer, ændres “Server name” til dit computernavn, og “Authentication” til det, der passer til den server.
Åbn RestoreDb.sql og kør query med F5. Så oprettes databasen.
