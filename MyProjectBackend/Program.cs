using MyProjectBackend.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json");
builder.Services.RegisterServices(builder.Configuration);
builder.Services.BuildMiddleware(builder);

var app = builder.Build();
app.BuildApp();
app.Run();
