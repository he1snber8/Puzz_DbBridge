using MyProjectBackend.DTO;
using System.Linq.Expressions;

namespace MyProjectBackend.Facade.Interfaces;

public interface ICompositeRepository<TComposite>
    where TComposite : IBasicEntity
{
    void Insert(TComposite entity);
    void Delete(TComposite entity);
    IQueryable<TComposite> Set(Expression<Func<TComposite, bool>> predicate);
}

public interface IRepositoryBase<TEntity> : ICompositeRepository<TEntity>
    where TEntity : IEntity
{
    void Update(TEntity entity);
    IQueryable<TEntity> Set();
    void Delete(object id);
    TEntity Get(params object[] id);
}
