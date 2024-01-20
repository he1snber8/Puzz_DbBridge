using MyProjectBackend.Facade.Models;

namespace MyProjectBackend.Services.Interfaces.Commands;

public interface IUserCommand : ICommandModel<UserModel> { }

public interface IIntererestCommand : ICommandModel<InterestModel> { }

public interface IMatchCommand : ICommandModel<MatchModel>
{
    Task TerminateMatch(int id);
}




