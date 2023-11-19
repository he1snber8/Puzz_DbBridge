using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Tests.AdditionalLogic.DummyObjects;

namespace MyProjectBackend.Tests;

public sealed class UserRepositoryTest : RepositoryBaseTest<User,IUserRepository>
{
    public UserRepositoryTest(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository) { }

    protected override User CreateEntity() {

        var getUser = UserDummyStorage.GetRandomDummy();

        return new User()
        {
            Username = getUser.Username,
            Email = getUser.Email,
            Password = getUser.Password
        };
            
     }

    protected override User UpdateEntity(User user)
    {
        var getUser = UserDummyStorage.GetRandomDummy();

        user.Username = $"{getUser.Username} updated!!";

        return user;      
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override User InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();

    [Theory]
    [InlineData(3,8)]
    public void AddInterestTest_A(int UserId, int interestId)
    {
        _unitOfWork.UserInterestRepository.Insert(new UserInterest { UserId = UserId, InterestId = interestId });
        _unitOfWork.SaveChanges();

        var insertedUserInterest = _unitOfWork.UserInterestRepository.Set(a => a.UserId == UserId && a.InterestId == interestId).SingleOrDefault();

        Assert.NotNull(insertedUserInterest);
        Assert.Equal(UserId, insertedUserInterest.UserId);
        Assert.Equal(interestId, insertedUserInterest.InterestId);
    }

    [Theory]
    [InlineData(3)]
    public void AddInterestTest_B(int interestId)
    {
        var user = InsertEntityTest();

        AddInterestTest_A(interestId,user.Id);
    }

}


