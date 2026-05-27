using Microsoft.EntityFrameworkCore;
using MyBlogApp.Models;
using MyBlogApp.Data.Configurations;

namespace MyBlogApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
    }
}
