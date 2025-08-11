
namespace TaskManagerAPI.Entidades
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // Navegación
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
    }
}
