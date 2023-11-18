
namespace MyProjectBackend.Facade.Models;

public record MatchModel : IEntityModel
{
    public int Id { get; }
    public DateTime ChatStart { get; }
    public DateTime? ChatEnd { get; }
    public string? ChatHistory { get; }

    public int User1Id { get; }
    public int User2Id { get; }
}
