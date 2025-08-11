using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.interfaces;

namespace TaskManagerAPI.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] global::Task task)
    {
        if (task == null || string.IsNullOrWhiteSpace(task.Title))
        {
            return BadRequest("Title is required");
        }

        try
        {
            task.CreatedAt = DateTime.UtcNow;
            task.Completed = false;

            var createdTask = await TaskService.InsertTaskAsync(task);
            return CreatedAtAction(nameof(GetAll), new { id = createdTask.Id }, createdTask);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] global::Task taskUpdate)
    {
        if (taskUpdate == null || id != taskUpdate.Id)
        {
            return BadRequest("Invalid task data");
        }

        try
        {
            taskUpdate.UpdatedAt = DateTime.UtcNow;
            var updatedTask = await TaskService.UpdateTaskAsync(taskUpdate);

            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await TaskService.DeleteTaskAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}