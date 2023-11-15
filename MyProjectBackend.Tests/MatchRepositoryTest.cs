using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Tests;

public class MatchRepositoryTest : RepositoryBaseTest<Match, IMatchRepository>
{
    public MatchRepositoryTest(IUnitOfWork unitOfWork, IMatchRepository repository) : base(unitOfWork, repository) { }

    protected override Match CreateEntity()
    {
        return new Match()
        {
           User1Id = 1,
           User2Id = 2,
        };
    }

    protected override Match UpdateEntity(Match entity)
    {
        entity.ChatHistory = $"test test!!! {Random.Shared.Next(1, 100)}";

        return entity;
    }

    protected override void DeleteEntityTest() => base.DeleteEntityTest();

    public override void InsertEntityTest() => base.InsertEntityTest();

    protected override void UpdateEntityTest() => base.UpdateEntityTest();
}


