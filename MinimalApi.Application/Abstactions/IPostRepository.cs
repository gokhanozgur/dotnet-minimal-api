using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Abstactions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetAllPosts();
    Task<Post> GetPostById(int postId);
    Task<Post> CreatePost(Post post);
    Task<Post> UpdatePost(string postContent, int postId);
    Task DeletePost(int postId);
}