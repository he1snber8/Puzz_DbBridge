
namespace MyProjectBackend.DTO;

public class Interest : IEntity
{
    public int Id { get; }
    public string? Name { get; set; } 

    public ICollection<UserInterest>? UserInterests { get; set; }
}