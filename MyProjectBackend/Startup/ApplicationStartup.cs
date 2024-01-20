using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyProjectBackend.Facade;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Repositories;
using MyProjectBackend.Services.CommandService;
using MyProjectBackend.Services.Interfaces.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyProjectBackend.Startup;

public static class ApplicationStartup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<MyProjectDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"));
        });


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IInterestRepostiory, InterestRepository>();

        services.AddScoped<IUserCommand, UserCommandService>();
        services.AddScoped<IIntererestCommand, InterestCommandService>();
        services.AddScoped<IMatchCommand, MatchCommandService>();

        services.AddAutoMapper(typeof(Profiles).Assembly);
       
        return services;
    }

    public static void BuildApp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }

    public static void BuildMiddleware(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opts =>
        {
            opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme(new OpenApiSecurityScheme { Scheme = "Bearer", In = ParameterLocation.Header, Type = SecuritySchemeType.Http, BearerFormat = "JWT" }));
            opts.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                   new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } }, new List<string>()
                }
            });
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
            };
        });
    }
}
