namespace MyBlogApp.Models;

/// <summary>Represents a registered user of the blog platform.</summary>
/// <remarks>
/// Why did the user log out? Because they couldn't find their <c>session</c>!
/// </remarks>
public record User
{
    /// <summary>The unique identifier for the user.</summary>
    public int Id { get; init; }

    /// <summary>The user's display name.</summary>
    public string Username { get; set; } = default!;

    /// <summary>The user's email address.</summary>
    public string Email { get; set; } = default!;

    /// <summary>The hashed password for the user account.</summary>
    public string PasswordHash { get; set; } = default!;

    /// <summary>The date and time the user registered.</summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>Indicates whether the user account is active.</summary>
    public bool IsActive { get; set; }
}
