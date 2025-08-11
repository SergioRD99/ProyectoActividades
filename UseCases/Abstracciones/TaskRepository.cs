using UseCases.interfaces;

namespace UseCases.Abstracciones
{
    public class TaskRepository : ITask
    {
        public Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Task> InsertTaskAsync(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<Task> UpdateTaskAsync(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
