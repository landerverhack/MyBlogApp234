using Microsoft.EntityFrameworkCore;
using MyBlogApp.Models;
using MyBlogApp.Data.Configurations;

namespace MyBlogApp.Data;

/// <summary>
/// The Entity Framework Core database context for the MyBlogApp application.
/// Provides access to the application's database tables and applies entity configurations.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="AppDbContext"/> with the specified options.
    /// </summary>
    /// <param name="options">The options to configure this context, such as the database provider and connection string.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="BlogPost"/> entities,
    /// representing the blog posts table in the database.
    /// </summary>
    public DbSet<BlogPost> BlogPosts { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Author"/> entities,
    /// representing the authors table in the database.
    /// </summary>
    public DbSet<Author> Authors { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="User"/> entities,
    /// representing the users table in the database.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Configures the entity models using the Fluent API.
    /// Applies <see cref="BlogPostConfiguration"/> to set up the <see cref="BlogPost"/> entity mapping.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
