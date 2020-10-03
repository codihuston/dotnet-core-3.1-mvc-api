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
    // Should be able to use nameof opertor to get method name, but Les has encountered issues with that.
    // So, just explicitly name it
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult <CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if(commandItem != null){
        return Ok(_mapper.Map<CommandReadDto>(commandItem)); 
      }
      return NotFound();
    }

    // POST api/commands
    [HttpPost]
    public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      // mapp the incoming DTO into a Command model
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      // add model to dbset
      _repository.CreateCommand(commandModel);
      // persist changes
      _repository.SaveChanges();

      // convert to a DTO (for return)
      var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

      // return the DTO for the model that was just created
      return CreatedAtRoute(nameof(GetCommandById),
                            new { Id = commandReadDto.Id },
                            commandReadDto);
    }
  }
}