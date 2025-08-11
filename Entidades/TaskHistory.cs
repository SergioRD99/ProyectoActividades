namespace Entidades;

public class TaskHistory
{
    public int Id { get; set; }
    public int TaskId { get; set; }     // FK
    public int ChangedBy { get; set; }  // FK
    public DateTime ChangeDate { get; set; }
    public string ChangeDescription { get; set; } = null!;

    // Navegación
    public Task Task { get; set; } = null!;
    public User ChangedByUser { get; set; } = null!;
}