using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<global::Task>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .AsNoTracking()
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<global::Task> InsertTaskAsync(global::Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<global::Task> UpdateTaskAsync(global::Task task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.Id);
            if (existingTask == null)
                return null;

            // Update only the allowed fields
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Completed = task.Completed;
            existingTask.UpdatedAt = DateTime.UtcNow;

            // Optional fields that can be updated
            if (task.DueDate.HasValue)
                existingTask.DueDate = task.DueDate;

            if (!string.IsNullOrEmpty(task.Priority))
                existingTask.Priority = task.Priority;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
