namespace Entidades;

public class Task
{
    public int Id { get; set; }
    public int UserId { get; set; } // FK
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public string Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navegación
    public User User { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<TaskHistory> History { get; set; } = new List<TaskHistory>();
}