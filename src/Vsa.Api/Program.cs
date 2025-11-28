using FastEndpoints;
using FastEndpoints.Swagger;
using Vsa.Api.Extensions;
using Vsa.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterDbContext(builder.Configuration)
    .RegisterFastEndpoints();

var app = builder.Build();
app.UseApplicationDb();
app.UseRouting();
app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});
app.UseSwaggerGen();

app.Run();
