using MediatR;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.CommandHandlers;

public class CreatePostHandler:IRequestHandler<CreatePost,Post>
{

    private readonly IPostRepository _postRepo;

    public CreatePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Content = request.PostContent
        };
        return await _postRepo.CreatePost(post);
    }
}