using MediatR;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Queries;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.QueryHandlers;

public class GetPostByIdHandler: IRequestHandler<GetPostById, Post>
{
    private readonly IPostRepository _postRepo;

    public GetPostByIdHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }
    
    public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _postRepo.GetPostById(request.PostId);
    }
}