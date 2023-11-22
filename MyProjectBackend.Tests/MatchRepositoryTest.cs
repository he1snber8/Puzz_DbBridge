using Microsoft.EntityFrameworkCore;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Tests;

public sealed class MatchRepositoryTest : RepositoryBaseTest<Match, IMatchRepository>
{
    public MatchRepositoryTest(IUnitOfWork unitOfWork, IMatchRepository repository) : base(unitOfWork, repository) { }

    protected override Match CreateEntity()
    {
        return new Match()
        {
           User1Id = 2,
           User2Id = 3,
        };
    }

    protected override Match UpdateEntity(Match entity)
    {
        entity.ChatHistory = $"test test!!! {Random.Shared.Next(1, 100)}";

        return entity;
    }

    [Fact]
    public void CollisionUserTest() => Assert.Throws<DbUpdateException>(InsertEntityTest); //for this case to be successful
                                                                                           //id's should be the same on users
    public override void DeleteEntityTest() => base.DeleteEntityTest();

    public override Match InsertEntityTest() => base.InsertEntityTest();

    public override void UpdateEntityTest() => base.UpdateEntityTest();
}


