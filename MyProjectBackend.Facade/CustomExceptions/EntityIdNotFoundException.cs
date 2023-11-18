namespace MyProjectBackend.Facade.CustomExceptions;

public class EntityIdNotFoundException : Exception
{
    public EntityIdNotFoundException(int id) : base($"Entity with given id: {id} is not found") { }
}
