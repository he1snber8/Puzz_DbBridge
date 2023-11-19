using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;

namespace MyProjectBackend.Services;

public class BaseCommandService<TEntityModel> : ICommandModel<TEntityModel>
    where TEntityModel : class, IEntityModel
{
    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Insert(TEntityModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, TEntityModel model)
    {
        throw new NotImplementedException();
    }
}
