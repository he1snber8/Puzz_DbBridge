namespace MyProjectBackend.DTO;

public interface IEntity : IEntity<int> { }

public interface IJunction { }

public interface IDeletable { bool IsDeleted { get; set; } }

public interface IEntity<out T> : IJunction { T Id { get; } }