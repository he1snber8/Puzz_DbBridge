using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Tests.AdditionalLogic.DummyObjects;

namespace MyProjectBackend.Tests;

public class InterestRepositoryTest : RepositoryBaseTest<Interest, IInterestRepostiory>
{
    public InterestRepositoryTest(IUnitOfWork unitOfWork, IInterestRepostiory repository) : base(unitOfWork, repository) { }

    protected override Interest CreateEntity()
    {
        return new Interest()
        {
            Name = InterestDummyStorage.GetRandomDummy()
        };
    }

    protected override Interest UpdateEntity(Interest entity)
    {
        entity.Name = InterestDummyStorage.GetRandomDummy() + " updated!";

        return entity;
    }

    [Theory]
    [InlineData(9)]
    public void DeleteEntityTest_S(int id)
    {
        var userInterest = _unitOfWork.UserInterestRepository.Set(ui => ui.InterestId == id);

        UserInterest[] userInterests = userInterest.ToArray();

        var interest = _repository.Get(id);

        if (userInterest == null)
        {
            Assert.Null(userInterest);
            _repository.Delete(interest);
            _unitOfWork.SaveChanges();
            Assert.Null(_repository.Get(interest));
            return;
        }

        foreach (var userInterestItem in userInterest)
        {
            Assert.NotNull(userInterestItem);

            _unitOfWork.UserInterestRepository.Delete(new UserInterest { InterestId = userInterestItem.InterestId, UserId = userInterestItem.UserId });
        }

        _repository.Delete(interest.Id);
        _unitOfWork.SaveChanges();

      
        Assert.Empty(_unitOfWork.UserInterestRepository.Set
           (ui =>  ui.InterestId == id).ToArray());
    }

    public override Interest InsertEntityTest() => base.InsertEntityTest();

    public override void UpdateEntityTest() => base.UpdateEntityTest();
}



