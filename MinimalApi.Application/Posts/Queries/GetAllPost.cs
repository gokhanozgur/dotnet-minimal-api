using MediatR;
using MinimalApi.Domain.Models;

namespace MinimalApi.Application.Posts.Queries;

public class GetAllPost:IRequest<ICollection<Post>>
{
    
}