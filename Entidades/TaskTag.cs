namespace Entidades;

public class TaskTag
{
    public int TaskId { get; set; } // PK + FK
    public int TagId { get; set; }  // PK + FK

    // Navegación
    public Task Task { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}