using Microsoft.EntityFrameworkCore;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using System.Linq.Expressions;

namespace MyProjectBackend.Repositories;

public abstract class CompositeRepositoryBase<TComposite> : DbContextConnector<TComposite, MyProjectDbContext>, ICompositeRepository<TComposite>
    where TComposite : class, IBasicEntity
{
    public CompositeRepositoryBase(MyProjectDbContext context) : base (context) { }
 
    public void Delete(TComposite entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
    }

    public void Insert(TComposite entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Add(entity);
    }

    public IQueryable<TComposite> Set(Expression<Func<TComposite, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public void Update(TComposite entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
    }
}