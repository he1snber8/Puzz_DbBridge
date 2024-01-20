using Microsoft.AspNetCore.Mvc;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;

namespace MyProjectBackend.Controllers;

public class MatchCommandController : BaseCommandController<MatchModel, IMatchCommand>
{
    public MatchCommandController(IMatchCommand command) : base(command) { }

    public override IActionResult Insert([FromBody] MatchModel model) =>  base.Insert(model);
                                  
    public override IActionResult Delete(int id) =>  base.Delete(id);
                                  
    public override IActionResult Update(int id, MatchModel model) =>  base.Update(id, model);
}