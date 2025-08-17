CineManager Full - ejemplo generado

- Proyecto: CineManager (ASP.NET Core 8 MVC)
- DB: SQLite (cine.db incluido, con seed)
- Migrations: folder with InitialCreate.sql

Instrucciones:
1. Abrir CineManager en VS Code / Visual Studio
2. dotnet restore
3. dotnet run
4. (Opcional) Para usar EF migrations: dotnet tool install --global dotnet-ef; dotnet ef migrations add InitialCreate; dotnet ef database update
