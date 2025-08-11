using Microsoft.EntityFrameworkCore;
using Entidades;

namespace UseCases.Abstracciones
{
    public interface IApplicationDbContext
    {
        DbSet<Entidades.Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TaskHistory> TaskHistories { get; set; }
        DbSet<TaskTag> TaskTags { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
