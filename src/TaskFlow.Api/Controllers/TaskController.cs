using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListTasks()
        {
            return Ok();
        }
    }
}
