using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("MyProjectBackend.Tests")]
#endif

namespace MyProjectBackend.Repositories;

public class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(MyProjectDbContext context) : base(context) { }
}
