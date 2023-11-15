using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

public class InterestRepositoryTest : RepositoryBaseTest<Interest, IInterestRepostiory>
{
    public InterestRepositoryTest(IUnitOfWork unitOfWork, IInterestRepostiory repository) : base(unitOfWork, repository) { }

    protected override Interest CreateEntity()
    {
        throw new NotImplementedException();
    }

    protected override Interest UpdateEntity(Interest entity)
    {
        throw new NotImplementedException();
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override void InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();
}



