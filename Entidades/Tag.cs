namespace Entidades;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // Navegación
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}