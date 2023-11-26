using MyProjectBackend.DTO;
using AutoMapper;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;
using MyProjectBackend.Facade.Interfaces;

namespace MyProjectBackend.Services.CommandService;

public class InterestCommandService : BaseCommandService<InterestModel, Interest, IInterestRepostiory>, IIntererestCommand
{
    public InterestCommandService(IUnitOfWork unitOfWork, IMapper mapper, IInterestRepostiory repository) : base(unitOfWork, mapper, repository) { }
}
