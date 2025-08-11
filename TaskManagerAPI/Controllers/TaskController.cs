using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Entidades;
using TaskManagerAPI.interfaces;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITask _taskService;

    public TaskController(ITask taskService)
    {
        _taskService = taskService;
    }

    // GET /tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    // POST /tasks
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] string title, [FromQuery] string? description = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Title is required");

        var newTask = new TaskActivity
        {
            Title = title,
            Description = description,
            CreatedAt = DateTime.UtcNow,
            Completed = false
        };

        var createdTask = await _taskService.InsertTaskAsync(newTask);
        return CreatedAtAction(nameof(GetAll), new { id = createdTask.Id }, createdTask);
    }

    // PUT /tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromQuery] string? title = null,
        [FromQuery] string? description = null,
        [FromQuery] bool? completed = null)
    {
        var existingTasks = await _taskService.GetAllTasksAsync();
        var taskToUpdate = existingTasks.FirstOrDefault(t => t.Id == id);
        if (taskToUpdate == null)
            return NotFound();

        if (!string.IsNullOrWhiteSpace(title))
            taskToUpdate.Title = title;

        if (description != null)
            taskToUpdate.Description = description;

        if (completed.HasValue)
            taskToUpdate.Completed = completed.Value;

        taskToUpdate.UpdatedAt = DateTime.UtcNow;

        var updatedTask = await _taskService.UpdateTaskAsync(taskToUpdate);
        return Ok(updatedTask);
    }

    // DELETE /tasks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _taskService.DeleteTaskAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
