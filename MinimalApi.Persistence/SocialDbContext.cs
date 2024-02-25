using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Models;

namespace MinimalApi.Persistence;

public class SocialDbContext:DbContext
{
    public SocialDbContext(DbContextOptions<SocialDbContext> opt):base(opt)
    {
        
    }
    
    public DbSet<Post> Posts { get; set; }
}