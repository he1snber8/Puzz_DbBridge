using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Repositories;

internal class UserInterestRepository : CompositeRepositoryBase<UserInterest>, IUserInterestRepository
{
    public UserInterestRepository(MyProjectDbContext context) : base(context) { }
}