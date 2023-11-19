namespace MyProjectBackend.DTO;

public interface IEntity : IEntity<int> { }

public interface IBasicEntity { }

public interface IDeletable { bool IsDeleted { get; set; } }

public interface IEntity<out T> : IBasicEntity { T Id { get; } }
