using MyProjectBackend.Facade.Models;
using System.Linq.Expressions;

namespace MyProjectBackend.Services.Interfaces.Queries;

public interface IQueryModel<TQueryModel>
    where TQueryModel : class, IEntityModel
{
    TQueryModel GetById(int id);
    IQueryable<TQueryModel> Set(Expression<Func<TQueryModel, bool>> predicate);
    IEnumerable<TQueryModel> Set();
}
