using TaskManagerAPI.Entidades;

namespace TaskManagerAPI.interfaces;

public interface ITask
{

    Task<IEnumerable<TaskActivity>> GetAllTasksAsync();
    Task<TaskActivity> InsertTaskAsync(TaskActivity task);
    Task<TaskActivity?> UpdateTaskAsync(TaskActivity task);
    Task<bool> DeleteTaskAsync(int taskId);
}