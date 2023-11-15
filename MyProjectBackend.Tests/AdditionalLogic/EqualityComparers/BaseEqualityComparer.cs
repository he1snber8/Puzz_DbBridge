
using MyProjectBackend.DTO;

namespace MyProjectBackend.Tests.AdditionalLogic.EqualityComparers;

public abstract class BaseEqualityComparer<TEntity> : IEqualityComparer<TEntity>
       where TEntity : class, IEntity
{
    public virtual bool Equals(TEntity? x,TEntity? y) =>
     x == null || y == null ? throw new ArgumentNullException(x == null ? nameof(x) : nameof(y)) : x.Id == y.Id;

    public virtual int GetHashCode(TEntity obj) => obj.Id.GetHashCode();
}
