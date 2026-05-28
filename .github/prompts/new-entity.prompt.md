---
description: "Scaffold a new EF Core entity: record model, Fluent API configuration, and AppDbContext registration"
name: "New Entity"
argument-hint: "Entity name and properties, e.g. 'Comment with Body (string), PostId (int), CreatedAt (DateTime)'"
agent: "agent"
---

Scaffold a new EF Core entity for this Blazor Web App (.NET 10) project. Follow the conventions in [AGENTS.md](../../AGENTS.md) exactly.

## Task

The entity to create is: **$input** (if not provided, ask the user for the entity name and its properties before proceeding).

## Steps

### 1 — Create the model record in `Models/<EntityName>.cs`

- Use a **record** (not a class), file-scoped namespace `MyBlogApp.Models`.
- Add **XML doc comments** on every property.
- Add **one dad joke** as an XML `<remarks>` comment on the record itself — make it relevant to the entity's domain if possible.
- No data annotations — constraints go in the configuration file only.

Example shape (adapt property names/types to the requested entity):

```csharp
namespace MyBlogApp.Models;

/// <summary>A <EntityName> entity.</summary>
/// <remarks>
/// Why did the <domain thing> go to school? Because it wanted to improve its <pun>! 🥁
/// </remarks>
public record <EntityName>
{
    /// <summary>The unique identifier.</summary>
    public int Id { get; init; }

    // ... other properties
}
```

### 2 — Create the Fluent API configuration in `Data/Configurations/<EntityName>Configuration.cs`

- Implement `IEntityTypeConfiguration<<EntityName>>`.
- File-scoped namespace `MyBlogApp.Data.Configurations`.
- Define all constraints (max lengths, required fields, default values, relationships) using Fluent API only.
- Add XML doc comments on the class and the `Configure` method.

### 3 — Update `Data/AppDbContext.cs`

- Add a `DbSet<<EntityName>>` property with an XML doc comment.
- Register the configuration inside `OnModelCreating` with `modelBuilder.ApplyConfiguration(new <EntityName>Configuration())`.

## Conventions Reminder

- File-scoped namespaces everywhere.
- Records for entities.
- Fluent API only — no data annotations on models.
- `@rendermode InteractiveServer` only needed when adding interactive Razor components (not required here).
