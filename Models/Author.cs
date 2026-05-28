namespace MyBlogApp.Models;

public record Author
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}