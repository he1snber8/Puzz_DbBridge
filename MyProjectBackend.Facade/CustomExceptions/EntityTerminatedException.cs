using MyProjectBackend.Facade.Models;

namespace MyProjectBackend.Facade.CustomExceptions;

public class EntityTerminatedException<TEntityModel> : Exception
    where TEntityModel : IEntityModel
{
    public EntityTerminatedException(int id, DateTime? endDate) 
        : base($"Entity with the given id: {id}, has been already terminated. Timestamp of termination {endDate}  ") { }
}