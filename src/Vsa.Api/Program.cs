using FastEndpoints;
using FastEndpoints.Swagger;
using Vsa.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterDbContext(builder.Configuration) 
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseRouting();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
