# MyBlogApp — Agent Instructions

A Blazor Web App (.NET 10) blog platform using server-side rendering and SQLite via EF Core.

## Build & Run

```bash
dotnet restore
dotnet build
dotnet run        # Dev server on https://localhost:7xxx (see Properties/launchSettings.json)
```

## Project Structure

| Folder | Purpose |
|--------|---------|
| `Components/Pages/` | Routable Razor pages (`@page` directive) |
| `Components/Layout/` | Layout components (`MainLayout`, `ChatGPTLayout`, `NavMenu`) |
| `Data/` | `AppDbContext` + EF Core Fluent API configurations |
| `Data/Configurations/` | One `IEntityTypeConfiguration<T>` file per entity |
| `Models/` | Domain entities (plain C# classes, no data annotations) |
| `wwwroot/` | Static assets; Bootstrap in `wwwroot/lib/bootstrap/` |

## Key Conventions

- **Entity configuration**: Use Fluent API only (`Data/Configurations/`), no data annotations on models. Register with `modelBuilder.ApplyConfiguration(new XyzConfiguration())` in `AppDbContext.OnModelCreating`.
- **Namespaces**: File-scoped namespaces (`namespace MyBlogApp.Data;`).
- **Rendering mode**: Interactive server components — use `@rendermode InteractiveServer` when a component needs interactivity.
- **Global Razor usings**: Defined in `Components/_Imports.razor`; add shared namespaces there.
- **use records for Entities**

## Database

- Provider: SQLite via `Microsoft.EntityFrameworkCore.Sqlite` (v10.0.8)
- Connection string key: `"DefaultConnection"` in `appsettings.json` under `ConnectionStrings`
- ⚠️ `appsettings.json` currently lacks this key — add it before running EF commands:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=myblog.db"
  }
  ```
- EF Core migrations: `dotnet ef migrations add <Name>` / `dotnet ef database update`

## Entities

- [`Models/BlogPost.cs`](Models/BlogPost.cs) — `Id`, `Title`, `Content`, `Author`, `CreatedAt`, `UpdatedAt?`, `IsPublished`
- [`Data/Configurations/BlogPostConfiguration.cs`](Data/Configurations/BlogPostConfiguration.cs) — constraints: Title ≤ 200, Author ≤ 100, `IsPublished` default `false`
