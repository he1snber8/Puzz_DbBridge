using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Repositories;

public class InterestRepository : RepositoryBase<Interest>, IInterestRepostiory
{
    public InterestRepository(MyProjectDbContext context) : base(context) { }
}
