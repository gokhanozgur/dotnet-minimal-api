using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstactions;
using MinimalApi.Application.Posts.Commands;
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

app.UseAuthorization();

app.MapControllers();

app.Run();