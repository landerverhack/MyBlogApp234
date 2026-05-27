using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApp.Models;

namespace MyBlogApp.Data.Configurations;

/// <summary>
/// EF Core entity type configuration for <see cref="BlogPost"/>.
/// Maps the entity to the "BlogPosts" table and enforces column constraints.
/// </summary>
public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    /// <summary>
    /// Configures the <see cref="BlogPost"/> entity:
    /// <list type="bullet">
    ///   <item><description><see cref="BlogPost.Title"/> — required, max 200 characters.</description></item>
    ///   <item><description><see cref="BlogPost.Content"/> — required.</description></item>
    ///   <item><description><see cref="BlogPost.Author"/> — required, max 100 characters.</description></item>
    ///   <item><description><see cref="BlogPost.CreatedAt"/> — required.</description></item>
    ///   <item><description><see cref="BlogPost.UpdatedAt"/> — optional.</description></item>
    ///   <item><description><see cref="BlogPost.IsPublished"/> — required, defaults to <c>false</c>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Content)
            .IsRequired();

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.CreatedAt)
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        builder.Property(b => b.IsPublished)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
