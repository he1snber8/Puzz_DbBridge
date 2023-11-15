namespace MyProjectBackend.Facade.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IInterestRepostiory InterestRepository { get; }
    IUserInterestRepository UserInterestRepository { get; }
    IMatchRepository MatchRepository { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
    void SaveChanges();
    Task SaveChangesAsync();
}
