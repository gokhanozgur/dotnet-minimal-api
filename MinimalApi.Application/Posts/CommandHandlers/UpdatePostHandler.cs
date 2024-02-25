using MediatR;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.CommandHandlers;

public class UpdatePostHandler: IRequestHandler<UpdatePost, Post>
{
    private readonly IPostRepository _postRepo;

    public UpdatePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        var post = await _postRepo.UpdatePost(request.PostContent, request.PostId);
        return post;
    }
}