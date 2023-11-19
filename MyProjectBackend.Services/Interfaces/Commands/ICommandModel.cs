using MyProjectBackend.Facade.Models;

namespace MyProjectBackend.Services.Interfaces.Commands;

public interface ICommandModel<TEntityModel>
    where TEntityModel : class, IEntityModel
{
    int Insert(TEntityModel model);
    void Update(int id, TEntityModel model);
    int Delete(int id);
}
