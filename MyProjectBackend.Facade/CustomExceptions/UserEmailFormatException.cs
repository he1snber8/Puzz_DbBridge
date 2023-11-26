namespace MyProjectBackend.Facade.CustomExceptions;

public class UserEmailFormatException : Exception
{
    public UserEmailFormatException(string email) : base($"Unexpected error happened with {email}, please check format again") { }
}

public class UserPasswordException : Exception
{
    public UserPasswordException(string password) 
        : base($"Unexpected error happened with password format {password}. Ensure that it is at least 6 characters long and has at least a single digit ") { }
}

public class UserUsernameException : Exception
{
    public UserUsernameException(string username)
        : base($"Unexpected error happened with username format {username}. Ensure that it is at least 5 characters long") { }
}