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
      
  }
}