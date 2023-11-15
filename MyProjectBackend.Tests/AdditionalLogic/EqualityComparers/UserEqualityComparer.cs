
using MyProjectBackend.DTO;


namespace MyProjectBackend.Tests.AdditionalLogic.EqualityComparers;

public class UserEqualityComparer : BaseEqualityComparer<User>
{
    public override bool Equals(User? x, User? y)
        => base.Equals(x, y) && x!.Email == y!.Email && x.RegistrationDate == y.RegistrationDate;
       
}
