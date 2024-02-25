using MediatR;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.Queries;

public class GetPostById:IRequest<Post>
{
    public int PostId { get; set; }
}