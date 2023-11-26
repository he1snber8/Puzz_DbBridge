using AutoMapper;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Queries;
using System.Linq.Expressions;
namespace MyProjectBackend.Services.QueryServices;

public abstract class BaseQueryService<TEntityModel, TEntity, TRepository> : IQueryModel<TEntityModel>
    where TEntityModel : class, IEntityModel
    where TEntity : class, IEntity
        //where TRepository : IRepositoryBase<TEntity>
{

    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IRepositoryBase<TEntity> _repository;
    protected abstract IRepositoryBase<TEntity> Repository();

    public BaseQueryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = Repository();
    }

    public TEntityModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntityModel> Set(Expression<Func<TEntityModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntityModel> Set()
    {
        throw new NotImplementedException();
    }
}