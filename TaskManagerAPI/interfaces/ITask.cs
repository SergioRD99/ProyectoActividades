namespace TaskManagerAPI.interfaces;

public interface ITask
{
    Task<IEnumerable<global::Task>> GetAllTasksAsync();
    Task<global::Task> InsertTaskAsync(global::Task task);
    Task<global::Task> UpdateTaskAsync(global::Task task);
    Task<bool> DeleteTaskAsync(int taskId);
}