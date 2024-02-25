using MediatR;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.Commands;

public class CreatePost:IRequest<Post>
{
    public string? PostContent { get; set; }
}