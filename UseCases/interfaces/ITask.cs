namespace UseCases.interfaces;

public interface ITask
{
    Task<IEnumerable<Entidades.Task>> GetAllTasksAsync();
    Task<Entidades.Task> InsertTaskAsync(Entidades.Task task);
    Task<Entidades.Task> UpdateTaskAsync(Entidades.Task task);
    Task<bool> DeleteTaskAsync(int taskId);
}