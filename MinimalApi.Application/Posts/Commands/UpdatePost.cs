using MediatR;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.Commands;

public class UpdatePost:IRequest<Post>
{
    public int PostId { get; set; }
    public string? PostContent { get; set; }
}