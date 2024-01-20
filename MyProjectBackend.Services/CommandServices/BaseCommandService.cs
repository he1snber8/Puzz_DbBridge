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

    protected TEntityModel? GetModel(int id) => _repository.Set(p => p.Id == id).SingleOrDefault() as TEntityModel
        ?? throw new EntityNotFoundException<TEntity>(id);

    public virtual async Task<int> Delete(int id)
    {
        var entity = _repository.Set(p => p.Id == id).SingleOrDefault() ??
            throw new EntityNotFoundException<TEntity>(id);

        if (entity is IDeletable deletableEntity)
            deletableEntity.IsDeleted = true;

         _repository.Update(entity!);
        await _unitOfWork!.SaveChangesAsync();

        return entity.Id;
    }

    public virtual async Task<int> Insert(TEntityModel model)
    {
        if (model is null) throw new ArgumentNullException("Inserted entity must not be null!");

        TEntity entity = _mapper.Map<TEntity>(model);

         _repository.Insert(entity);
        await _unitOfWork.SaveChangesAsync();

        return entity.Id;
    }

    public virtual async Task Update(int id, TEntityModel model)
    {
        var entity = _repository.Set(u => u.Id == id).SingleOrDefault()
           ?? throw new EntityNotFoundException<TEntity>(id);

        if (entity is IDeletable deletableEntity && deletableEntity.IsDeleted)
            throw new EntityNotFoundException<TEntity>(id);

           _repository.Update(entity);
           await _unitOfWork!.SaveChangesAsync();
    }
}
