using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);


var app = builder.Build();
app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
