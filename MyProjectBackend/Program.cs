
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProjectBackend.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyProjectDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

builder.Services.AddDbContext<MyProjectDbContextTest>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
