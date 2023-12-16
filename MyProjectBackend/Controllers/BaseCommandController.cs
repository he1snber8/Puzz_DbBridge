using Microsoft.AspNetCore.Mvc;
using MyProjectBackend.Facade.Models;
using MyProjectBackend.Services.Interfaces.Commands;

namespace MyProjectBackend.Controllers;

public abstract class BaseCommandController<TModel,TCommand> : Controller
    where TModel : class, IEntityModel
    where TCommand : ICommandModel<TModel>
{
    protected TCommand _command;

    public BaseCommandController(TCommand command)
    {
        _command = command;
    }

    [HttpPost("insert")]
    public virtual IActionResult Insert([FromBody] TModel model)
    {
        try
        {
            _command.Insert(model);
        }
        catch (Exception ex)
        {
            return BadRequest($"operation failed, reason: {ex.Message}");
        }

        return Ok("Entity inserted successfully!");
    }

    [HttpDelete("delete")]
    public virtual IActionResult Delete(int id)
    {
        try
        {
            _command.Delete(id);
        }
        catch (Exception ex)
        {
            return BadRequest($"operation failed, reason: {ex.Message}");
        }

        return Ok("Entity deleted successfully!");
    }


    [HttpPut("update")]
    public virtual IActionResult Update(int id, TModel model)
    {
        try
        {
            _command.Update(id,model);
        }
        catch (Exception ex)
        {
            return BadRequest($"operation failed, reason: {ex.Message}");
        }

        return Ok("Entity updated successfully");
    }
}
