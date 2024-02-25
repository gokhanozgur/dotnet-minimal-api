using MediatR;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Commands;

namespace MinimalApi.Application.Posts.CommandHandlers;

public class DeletePostHandler:IRequestHandler<DeletePost>
{
    private readonly IPostRepository _postRepo;

    public DeletePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _postRepo.DeletePost(request.PostId);
        return Unit.Value;
    }
}