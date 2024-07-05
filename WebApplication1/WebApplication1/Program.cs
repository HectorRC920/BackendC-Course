using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService, People2Service>();
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2Service");
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("RandomServiceSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("RandomServiceScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("RandomServiceTransient");

builder.Services.AddKeyedScoped<IPostsService, PostsService>("PostsService");

builder.Services.AddHttpClient<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

builder.Services.AddScoped<IBeerService, BeerService>();
//Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});
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
