namespace MyProjectBackend.DTO;

public class Match : IEntity, ITerminable
{
    public int Id { get; }
    public DateTime? EndDate { get; set; }
    public string? ChatHistory { get; set; }
    public bool? IsActive { get; set; }
    public DateTime StartDate { get; set; }

    public User? User1 { get; set; }
    public int User1Id { get; set; }

    public User? User2 { get; set; }
    public int User2Id { get; set;}
}
