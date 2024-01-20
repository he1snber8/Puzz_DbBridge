using MyProjectBackend.DTO;
using AutoMapper;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;
using MyProjectBackend.Facade.Interfaces;
using MyProjectBackend.Facade.CustomExceptions;

namespace MyProjectBackend.Services.CommandService;

public class UserCommandService : BaseCommandService<UserModel, User,IUserRepository>, IUserCommand
{
    public UserCommandService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository repository) : base(unitOfWork, mapper, repository) { }

    public override Task<int> Insert(UserModel model)
    {
        if (model.Username.Length < 5) throw new UserUsernameException(model.Username);
        if (model.Password.Length < 5 || !model.Password.Any(char.IsDigit)) throw new UserPasswordException(model.Password);
        if (model.Email.Length < 8 || !model.Email.Contains('@')) throw new UserEmailFormatException(model.Email);

        return base.Insert(model);
    }

    public override async Task<int> Delete(int id) => await base.Delete(id);

    public override async Task Update(int id, UserModel model)
    {
        await base.Update(id, model);
    }
        
}
