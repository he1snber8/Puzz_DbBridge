﻿using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Interfaces;

public abstract class RepositoryBaseTest<TEntity, TRepository>
    where TEntity : class, IEntity
    where TRepository : IRepositoryBase<TEntity>
{

    protected readonly IUnitOfWork _unitOfWork;
    protected readonly TRepository _repository;

    protected RepositoryBaseTest(IUnitOfWork unitOfWork, TRepository repository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    protected abstract TEntity CreateEntity();
    protected abstract TEntity UpdateEntity(TEntity entity);

    private TEntity FindEntity(int id) => _repository.Set(i => i.Id == id).SingleOrDefault() ?? throw new ArgumentException(nameof(id));

    [Fact]
    public virtual void InsertEntityTest()
    {
        var entity = CreateEntity();

        _repository.Insert(entity);
        _unitOfWork.SaveChanges();

        Assert.True(entity.Id > 0);
    }

    [Fact]
    protected virtual void UpdateEntityTest()
    {
        var insertedEntity = CreateEntity();

        var entity = UpdateEntity(insertedEntity);

        _repository.Update(entity);
        _unitOfWork.SaveChanges();

        Assert.True(insertedEntity.Id == entity.Id);
    }

    [Fact]
    protected virtual void DeleteEntityTest()
    {
        var entity = CreateEntity();

        _repository.Insert(entity);
        _unitOfWork.SaveChanges();

        int id = entity.Id;

        if(entity is IDeletable deletableEntity)
        {
            deletableEntity.IsDeleted = true;

            _repository.Update(entity);
            _unitOfWork.SaveChanges();

            Assert.True(entity.Id > 0);   
        }

        else
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
            Assert.Throws<KeyNotFoundException>(() => _repository.Get(id));
        }

    }
}

