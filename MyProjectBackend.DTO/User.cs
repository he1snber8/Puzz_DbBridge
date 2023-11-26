namespace MyProjectBackend.DTO;

public class User : IEntity, IDeletable
{
    public int Id { get; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte[]? Picture { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? RegistrationDate { get; set; }

    public ICollection<UserInterest>? UserInterests { get; set; }
}
