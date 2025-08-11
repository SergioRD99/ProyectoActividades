using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerAPI.Entidades;

public class Task
{
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool Completed { get; set; }

    public string Priority { get; set; }

    [Column("due_date")]
    public DateTime? DueDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    // Navegación
    public User User { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<TaskHistory> History { get; set; } = new List<TaskHistory>();
}