using MyProjectBackend.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json");
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.BuildApp();
app.Run();
