using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Queries;
using System.Linq.Expressions;

namespace MyProjectBackend.Services;

public class BaseQueryService<TQueryModel> : IQueryModel<TQueryModel>
    where TQueryModel : class, IEntityModel
{
    public TQueryModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TQueryModel> Set(Expression<Func<TQueryModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TQueryModel> Set()
    {
        throw new NotImplementedException();
    }
}