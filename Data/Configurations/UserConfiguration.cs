using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApp.Models;

namespace MyBlogApp.Data.Configurations;

/// <summary>Fluent API configuration for the <see cref="User"/> entity.</summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>Configures the <see cref="User"/> entity constraints and mappings.</summary>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(200).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.PasswordHash).HasMaxLength(500).IsRequired();
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.IsActive).HasDefaultValue(true);
    }
}
