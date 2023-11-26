using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(MyProjectDbContext context) : base(context) { }
}
