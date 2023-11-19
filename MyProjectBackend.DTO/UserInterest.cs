
namespace MyProjectBackend.DTO;

public class UserInterest : IBasicEntity
{
    public User? User { get; set; }
    public int UserId { get; set; }

    public Interest? Interest { get; set; }
    public int InterestId { get; set; }
}
