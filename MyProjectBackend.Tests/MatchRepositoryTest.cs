using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

public class MatchRepositoryTest : RepositoryBaseTest<Match, IMatchRepository>
{
    public MatchRepositoryTest(IUnitOfWork unitOfWork, IMatchRepository repository) : base(unitOfWork, repository) { }

    protected override Match CreateEntity()
    {
        throw new NotImplementedException();
    }

    protected override Match UpdateEntity(Match entity)
    {
        throw new NotImplementedException();
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override void InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();
}


