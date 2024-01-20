using MyProjectBackend.Facade.Models;

namespace MyProjectBackend.Services.Interfaces.Commands;

public interface ICommandModel<TEntityModel>
    where TEntityModel : class, IEntityModel
{
    Task<int> Insert(TEntityModel model);
    Task Update(int id, TEntityModel model);
    Task<int> Delete(int id);
}
