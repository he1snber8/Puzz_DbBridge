
namespace MyProjectBackend.Facade.Models;

public class MatchModel : IEntityModel
{ 
    public int Id { get; }
    public DateTime? EndDate { get; set; }
    public bool isActive { get; set; }
    public string? ChatHistory { get; }

    public int User1Id { get; }
    public int User2Id { get; }
}
