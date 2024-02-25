namespace MinimalApi.Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModified { get; set; }
}