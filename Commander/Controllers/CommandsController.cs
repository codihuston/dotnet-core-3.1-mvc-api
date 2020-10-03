using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
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

    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    
    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();

      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    // GET api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult <CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if(commandItem != null){
        return Ok(_mapper.Map<CommandReadDto>(commandItem)); 
      }
      return NotFound();
    }
  }
}