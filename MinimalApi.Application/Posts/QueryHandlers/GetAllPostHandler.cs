using MediatR;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Queries;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.QueryHandlers;

public class GetAllPostHandler:IRequestHandler<GetAllPost, ICollection<Post>>
{
    private readonly IPostRepository _postRepo;

    public GetAllPostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<ICollection<Post>> Handle(GetAllPost request, CancellationToken cancellationToken)
    {
        return await _postRepo.GetAllPosts();
    }
}