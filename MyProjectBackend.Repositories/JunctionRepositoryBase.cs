using Microsoft.EntityFrameworkCore;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using System.Linq.Expressions;

namespace MyProjectBackend.Repositories;

internal abstract class JunctionRepositoryBase<TJunction> : IRepositoryJunction<TJunction>
    where TJunction : class, IJunction
{
    protected readonly MyProjectDbContext _context;
    protected readonly DbSet<TJunction> _dbSet;

    public JunctionRepositoryBase(MyProjectDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TJunction>();
    }

    public void Delete(TJunction entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
    }

    public void Insert(TJunction entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Add(entity);
    }

    public IQueryable<TJunction> Set(Expression<Func<TJunction, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public void Update(TJunction entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
    }
}