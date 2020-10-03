using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("/")]
  // out-of-box behaviours that we get from the inhereted ControllerBase
  [ApiController]
  public class RootController : ControllerBase
  {

    private readonly ICommanderRepo _repository;

    public RootController(ICommanderRepo repository)
    {
      _repository = repository;
    }
    
    // GET /
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      return Ok(new { 
          test = "api is working"
      });
    }
  }
}