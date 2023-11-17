using MyProjectBackend.DTO;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProjectBackend.Facade.Interfaces;

public interface IRepositoryJunction<TJunction>
    where TJunction : IJunction
{
    void Insert(TJunction entity);
    void Delete(TJunction entity);
    IQueryable<TJunction> Set(Expression<Func<TJunction, bool>> predicate);
}

public interface IRepositoryBase<TEntity> : IRepositoryJunction<TEntity>
    where TEntity : IEntity
{
    void Update(TEntity entity);
    IQueryable<TEntity> Set();
    void Delete(object id);
    TEntity Get(params object[] id);
}
