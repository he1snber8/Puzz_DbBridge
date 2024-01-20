using Microsoft.AspNetCore.Mvc;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;

namespace MyProjectBackend.Controllers;

[ApiController]
[Route("api/commands/users")]
public class UserCommandController : BaseCommandController<UserModel, IUserCommand>
{
    public UserCommandController(IUserCommand command) : base(command) { }

    public override IActionResult Insert([FromBody] UserModel model) =>  base.Insert(model);

    public override IActionResult Delete(int id) =>  base.Delete(id);

    public override IActionResult Update(int id, UserModel model) =>  base.Update(id, model);
}
