using MyProjectBackend.DTO;

namespace MyProjectBackend.Facade.CustomExceptions;

public class EntityNotFoundException<TEntity> : Exception
    where TEntity : IEntity
{
    public EntityNotFoundException(int id)
        : base($"Entity with the given id: {id} has not been found. it is either deleted or not registered") { }
}
