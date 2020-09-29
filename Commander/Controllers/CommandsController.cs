using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  // controller-level routes: how you get to the endpoints in the controller
  /// api/commands (plugs in class name into the route; optional)
  //[Route("api/[controller]")]
  [Route("api/commands")]
  // out-of-box behaviours that we get from the inhereted ControllerBase
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly MockCommanderRepo _repository = new MockCommanderRepo();

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAppCommands();

      return Ok(commandItems);
    }

    // GET api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult <Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      return Ok(commandItem);
    }
  }
}