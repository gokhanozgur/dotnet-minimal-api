using MediatR;

namespace MinimalApi.Application.Posts.Commands;

public class DeletePost:IRequest
{
    public int PostId { get; set; }
}