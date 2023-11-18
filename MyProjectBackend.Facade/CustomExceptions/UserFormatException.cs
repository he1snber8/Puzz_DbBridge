namespace MyProjectBackend.Facade.CustomExceptions;

public class UserFormatException : Exception
{
    public UserFormatException(string email) : base($"Unexpected error happened with {email}, please check format again") { }
}
