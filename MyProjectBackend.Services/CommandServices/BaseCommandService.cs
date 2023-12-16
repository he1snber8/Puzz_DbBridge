using MyProjectBackend.DTO;
using AutoMapper;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Facade.CustomExceptions;

namespace MyProjectBackend.Services.CommandService;

public abstract class BaseCommandService<TEntityModel, TEntity,TRepository> : ICommandModel<TEntityModel>
    where TEntityModel : class, IEntityModel
    where TEntity : class, IEntity
    where TRepository : IRepositoryBase<TEntity>
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly TRepository _repository;

    public BaseCommandService(IUnitOfWork unitOfWork, IMapper mapper, TRepository repository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
    }

    protected TEntityModel GetModel(int id)
    {
        return _repository.Set(p => p.Id == id).SingleOrDefault() as TEntityModel
        ?? throw new EntityNotFoundException<TEntity>(id);
    }


    public virtual int Delete(int id)
    {
        var entity = _repository.Set(p => p.Id == id).SingleOrDefault()
        ?? throw new EntityNotFoundException<TEntity>(id);

        if (entity is IDeletable deletableEntity)
            deletableEntity.IsDeleted = true;

        _repository.Update(entity);
        _unitOfWork?.SaveChanges();

        return entity.Id;
    }

    public virtual int Insert(TEntityModel model)
    {
        if (model == null) throw new ArgumentNullException("Inserted entity must not be null!");

        TEntity entity = _mapper.Map<TEntity>(model);

        _repository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public virtual void Update(int id, TEntityModel model)
    {
        var entity = _repository.Set(u => u.Id == id).SingleOrDefault()
           ?? throw new EntityNotFoundException<TEntity>(id);

        if (entity is IDeletable deletableEntity && deletableEntity.IsDeleted)
            throw new EntityNotFoundException<TEntity>(id);

        model = _mapper.Map<TEntityModel>(entity);

        _repository.Update(entity);
        _unitOfWork!.SaveChanges();
    }
}
