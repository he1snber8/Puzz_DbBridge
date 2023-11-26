using Microsoft.EntityFrameworkCore;
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
        services.AddSwaggerGen();

        services.AddDbContext<MyProjectDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));
        });

        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IInterestRepostiory, InterestRepository>();

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<IUserCommand, UserCommandService>();
        services.AddScoped<IIntererestCommand, InterestCommandService>();
        services.AddScoped<IMatchCommand, MatchCommandService>();

        services.AddAutoMapper(typeof(Profiles).Assembly);
       
        return services;
    }
}
