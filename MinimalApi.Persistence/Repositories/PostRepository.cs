using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstactions;
using MinimalApi.Domain.Models;

namespace MinimalApi.Persistence.Repositories;

public class PostRepository: IPostRepository
{
    private readonly SocialDbContext _ctx;
    
    public PostRepository(SocialDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<ICollection<Post>> GetAllPosts()
    {
        return await _ctx.Posts.ToListAsync();
    }

    public async Task<Post> GetPostById(int postId)
    {
        return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<Post> CreatePost(Post post)
    {
        post.CreatedDate = DateTime.Now;
        post.LastModified = DateTime.Now;
        _ctx.Posts.Add(post);
        await _ctx.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePost(Post post, int postId)
    {
        var existingPost = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        existingPost.LastModified = DateTime.Now;
        existingPost.Content = post.Content;
        await _ctx.SaveChangesAsync();
        return post;
    }

    public async Task DeletePost(int postId)
    {
        var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (post == null) return;
        _ctx.Posts.Remove(post);
        await _ctx.SaveChangesAsync();
    }
}