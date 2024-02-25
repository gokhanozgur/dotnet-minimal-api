using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.Application.Posts.Queries;
using MinimalApi.Domain.Models;
using MinimalApi.Persistence;
using MinimalApi.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SocialDbContext>(options => options.UseSqlServer(defaultConnectionString));

builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddMediatR(typeof(CreatePost));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send(getPost);
    return Results.Ok(post);
}).WithName("GetPostById");

app.MapPost("/api/posts", async (IMediator mediator, Post post) =>
{
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { id = createdPost.Id }, createdPost);
});

app.MapGet("/api/posts", async (IMediator mediator) =>
{
    var getCommand = new GetAllPost();
    var posts = await mediator.Send(getCommand);
    return Results.Ok(posts);
});

app.MapPut("/api/posts/{id}", async (IMediator mediator, Post post, int id) =>
{
    var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
    var updatedPost = await mediator.Send(updatePost);
    return Results.Ok(updatedPost);
});

app.MapDelete("/api/posts/{id}", async (Mediator mediator, int id) =>
{
    var deletePost = new DeletePost { PostId = id };
    var deletedPost = await mediator.Send(deletePost);
    return Results.NoContent();
});

app.UseAuthorization();

//app.MapControllers();

app.Run();