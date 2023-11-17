using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Tests;

public class UserRepositoryTest : RepositoryBaseTest<User,IUserRepository>
{
    public UserRepositoryTest(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository) { }

    protected override User CreateEntity() {

        int indx = Random.Shared.Next(5, 1000);

        return new User()
        {
            Username = $"testUsername{indx}",
            Email = $"testMail{indx}",
            Password = $"testPswrd{indx}"
        };
            
     }

    protected override User UpdateEntity(User user)
    {
        user.Username = $"testUsername{Random.Shared.Next(5, 1000)} updated!!";

        return user;      
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override User InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();

    [Theory]
    [InlineData(3,5)]
    public void AddInterestFieldTest_A(int interestId,int UserId)
    {
        //var user = InsertEntityTest();

        _unitOfWork.UserInterestRepository.Insert(new UserInterest { UserId = UserId, InterestId = interestId });
        _unitOfWork.SaveChanges();

        var insertedUserInterest = _unitOfWork.UserInterestRepository.Set(a => a.UserId == UserId && a.InterestId == interestId).SingleOrDefault();

        Assert.NotNull(insertedUserInterest);
        Assert.Equal(UserId, insertedUserInterest.UserId);
        Assert.Equal(interestId, insertedUserInterest.InterestId);
    }

    [Theory]
    [InlineData(3)]
    public void AddInterestFieldTest_B(int interestId)
    {
        var user = InsertEntityTest();

        AddInterestFieldTest_A(interestId,user.Id);
    }

}


