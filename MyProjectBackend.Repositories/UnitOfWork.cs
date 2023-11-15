using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IDbContextTransaction? _transaction;
    private readonly MyProjectDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IInterestRepostiory> _interestRepostiory;
    private readonly Lazy<IMatchRepository> _matchRepository;
    private readonly Lazy<IUserInterestRepository> _userInterestRepository;

    public UnitOfWork(MyProjectDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
        _interestRepostiory = new Lazy<IInterestRepostiory>(() => new InterestRepository(context));
        _matchRepository = new Lazy<IMatchRepository>(() => new MatchRepository(context));
        _userInterestRepository = new Lazy<IUserInterestRepository>(() => new UserInterestRepository(context));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public IInterestRepostiory InterestRepository => _interestRepostiory.Value;
    public IUserInterestRepository UserInterestRepository => _userInterestRepository.Value;
    public IMatchRepository MatchRepository => _matchRepository.Value;

    public void BeginTransaction()
    {
        try
        {
            _transaction = _context.Database.BeginTransaction();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to begin transaction");
            throw;
        }
    }

    public void Commit()
    {
        try
        {
            _transaction?.Commit();
            _transaction?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to commit transaction");
            throw;
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public void SaveChanges()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DbContext error");
            throw;
        }

    }

    public void Dispose()
    {
        try
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to rollback transaction");
            throw;
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DbContext error");
            throw;
        }
    }
}