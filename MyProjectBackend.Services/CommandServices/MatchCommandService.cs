using MyProjectBackend.DTO;
using AutoMapper;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Facade.CustomExceptions;

namespace MyProjectBackend.Services.CommandService;

public class MatchCommandService : BaseCommandService<MatchModel, Match, IMatchRepository>, IMatchCommand
{
    public MatchCommandService(IUnitOfWork unitOfWork, IMapper mapper, IMatchRepository repository) : base(unitOfWork, mapper, repository) { }

    public override int Insert(MatchModel model) => base.Insert(model);

    public override int Delete(int id) => base.Delete(id);

    public override void Update(int id, MatchModel model) => base.Update(id, model);

    public void TerminateMatch(int id)
    {
        var model = GetModel(id);

        if (!model.isActive) throw new EntityTerminatedException<MatchModel>(model.Id, model.EndDate);

        var entity = _mapper.Map<Match>(model);

        entity.IsActive = false;
        entity.EndDate = DateTime.UtcNow;

        _repository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}
