using MyProjectBackend.DTO;

namespace MyProjectBackend.Facade.Interfaces;

public interface IInterestRepostiory : IRepositoryBase<Interest> { }

public interface IUserRepository : IRepositoryBase<User> { }

public interface IUserInterestRepository : ICompositeRepository<UserInterest> { }

public interface IMatchRepository : IRepositoryBase<Match> { }