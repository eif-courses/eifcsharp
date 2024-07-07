using FastEndpoints;
using FastEndpoints.Swagger;
using Tarifikacija;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen(); 

app.Run();
