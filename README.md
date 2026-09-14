# TodoApi .NET 9

API REST de gestion de taches construite avec ASP.NET Core, Entity Framework Core, SQL Server et Swagger/OpenAPI.

## Fonctionnalites

- CRUD complet sur les taches.
- Validation automatique des DTOs avec `DataAnnotations`.
- Documentation Swagger disponible en environnement de developpement.
- Acces SQL Server via Entity Framework Core.

## Prerequis

- .NET SDK 9.
- SQL Server accessible localement ou a distance.

## Configuration

La configuration locale peut etre placee dans `.env`, qui est ignore par Git :

```env
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://+:5080
ConnectionStrings__DefaultConnection=Server=localhost;Database=TodoDb;User Id=sa;Password=CHANGE_ME;TrustServerCertificate=True;Encrypt=True
```

Si `.env` est absent, l'application utilise la chaine de connexion de secours dans `appsettings.json` :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TodoDb;User Id=sa;Password=CHANGE_ME;TrustServerCertificate=True;Encrypt=True"
  }
}
```

Pour une configuration locale, utilisez `.env`, `appsettings.Local.json` ou des secrets utilisateur afin d'eviter de versionner des mots de passe reels.

## Lancer le projet

```powershell
dotnet restore
dotnet build
dotnet run
```

Swagger est ensuite disponible sur :

```text
http://localhost:5080/swagger
https://localhost:7080/swagger
```

## Docker

Les fichiers `Dockerfile`, `docker-compose.yml` et `.dockerignore` preparent un futur deploiement sur VPS. `docker-compose.yml` charge les variables depuis `.env`.

```powershell
docker compose up --build
```

## Endpoints principaux

- `GET /api/todos` : liste les taches.
- `GET /api/todos/{id}` : retourne une tache.
- `POST /api/todos` : cree une tache.
- `PUT /api/todos/{id}` : met a jour une tache.
- `DELETE /api/todos/{id}` : supprime une tache.
