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

    public override async Task<int> Insert(MatchModel model) => await base.Insert(model);

    public override async Task<int> Delete(int id) => await base.Delete(id);

    public override async Task Update(int id, MatchModel model) => await base.Update(id, model);

    public async Task TerminateMatch(int id)
    {
        var model = GetModel(id);

        if (!model!.isActive) throw new EntityTerminatedException<MatchModel>(model.Id, model.EndDate);

        var entity = _mapper.Map<Match>(model);

        entity.IsActive = false;
        entity.EndDate = DateTime.UtcNow;

        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }
}
