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
            Name = DummyStorage.GetRandomDummy()
        };
    }

    protected override Interest UpdateEntity(Interest entity)
    {
        entity.Name = DummyStorage.GetRandomDummy() + " updated!";

        return entity;
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override void InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();
}



