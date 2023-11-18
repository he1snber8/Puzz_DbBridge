namespace MyProjectBackend.Facade.Models;

public class UserModel : IEntityModel
{
    public int Id { get; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte[]? Picture { get; set; }
}
