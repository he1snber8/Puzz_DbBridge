using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Repositories;

namespace MyProjectBackend.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyProjectDbContext>(options => options.UseSqlite(@"Data Source =C:\Users\lukak\OneDrive\Desktop\Sqlite\Demo.db"));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInterestRepostiory, InterestRepository>();
        services.AddScoped<IUserInterestRepository, UserInterestRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
    }
}