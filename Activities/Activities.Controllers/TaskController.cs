using Microsoft.AspNetCore.Mvc;

namespace Activities.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class TaskController : ControllerBase
    {

        public TaskController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTask()
        {
            return Ok();
        }
    }
}
