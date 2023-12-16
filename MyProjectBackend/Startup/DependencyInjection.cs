using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.OpenApi.Models;
using MyProjectBackend.Facade;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Repositories;
using MyProjectBackend.Services.CommandService;
using MyProjectBackend.Services.Interfaces.Commands;

namespace MyProjectBackend.Startup;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
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
}
