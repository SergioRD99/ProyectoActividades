namespace UseCases.interfaces;

public interface ITask
{
    Task<IEnumerable<Task>> GetAllTasksAsync();
    Task<Task> InsertTaskAsync(Task task);
    Task<Task> UpdateTaskAsync(Task task);
    Task<bool> DeleteTaskAsync(int taskId);
}