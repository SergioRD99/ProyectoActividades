using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Entidades;
using TaskManagerAPI.interfaces;

namespace TaskManagerAPI.Abstracciones
{
    public class TaskRepository : ITask
    {
        private readonly IApplicationDbContext _context;

        public TaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskActivity>> GetAllTasksAsync()
        {
            // Trae todas las tareas
            return await _context.TaskActivitys.ToListAsync();
        }

        public async Task<TaskActivity> InsertTaskAsync(TaskActivity task)
        {
            task.CreatedAt = DateTime.UtcNow;
            task.Completed = false;
            if (task.Description.IsNullOrEmpty())
            {
                task.Description = "";
            }

            _context.TaskActivitys.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskActivity?> UpdateTaskAsync(TaskActivity task)
        {
            var existingTask = await _context.TaskActivitys.FindAsync(task.Id);
            if (existingTask == null) return null;

            // Actualiza solo los campos permitidos
            if (!string.IsNullOrEmpty(task.Title))
                existingTask.Title = task.Title;

            existingTask.Description = task.Description;

            existingTask.Completed = task.Completed;

            existingTask.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var existingTask = await _context.TaskActivitys.FindAsync(taskId);
            if (existingTask == null) return false;

            _context.TaskActivitys.Remove(existingTask);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}