namespace MyProjectBackend.DTO;

public class Match : IEntity, IDeletable
{
    public int Id { get; }
    public DateTime ChatEnd { get; set; }
    public string? ChatHistory { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime ChatStart { get; set; }

    public User? User1 { get; set; }
    public int User1Id { get; set; }

    public User? User2 { get; set; }
    public int User2Id { get; set;}
}
