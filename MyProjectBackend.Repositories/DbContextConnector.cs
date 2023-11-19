using Microsoft.EntityFrameworkCore;
using MyProjectBackend.DTO;

namespace MyProjectBackend.Repositories;

public abstract class DbContextConnector<TEntity,TDbContext>
    where TEntity : class, IBasicEntity
    where TDbContext : DbContext
{
    protected readonly TDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public DbContextConnector(TDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }
}