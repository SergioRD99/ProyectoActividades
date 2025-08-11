using Microsoft.AspNetCore.Mvc;
using UseCases.interfaces;

namespace TaskManagerAPI;


[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITask TaskService;
    public TaskController(ITask taskService)
    {
        TaskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await TaskService.GetAllTasksAsync();
        return Ok(tasks);
    }

}