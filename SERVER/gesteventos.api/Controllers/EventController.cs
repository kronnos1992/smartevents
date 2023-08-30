using Microsoft.AspNetCore.Mvc;

namespace gesteventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    public EventController()
    {

    }
    [HttpGet(Name = "GetEvent")]
    public string Get()
    {
        return "";
    }
}
