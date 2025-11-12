using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Vsa.Infra.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("vsa"));

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.AddScoped<Vsa.Application.Users.GetById.GetUserByIdHandler>();
builder.Services.AddScoped<Vsa.Application.Users.Create.CreateUserHandler>();
builder.Services.AddScoped<Vsa.Application.Users.Update.UpdateUserHandler>();
builder.Services.AddScoped<Vsa.Application.Users.Delete.DeleteUserHandler>();
builder.Services.AddScoped<Vsa.Application.Settings.GetById.GetSettingByIdHandler>();
builder.Services.AddScoped<Vsa.Application.Settings.Create.CreateSettingHandler>();
builder.Services.AddScoped<Vsa.Application.Settings.Update.UpdateSettingHandler>();
builder.Services.AddScoped<Vsa.Application.Settings.Delete.DeleteSettingHandler>();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
