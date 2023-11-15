using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Repositories;

internal class InterestRepository : RepositoryBase<Interest>, IInterestRepostiory
{
    public InterestRepository(MyProjectDbContext context) : base(context) { }
}
