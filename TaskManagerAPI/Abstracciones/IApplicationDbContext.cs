using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Entidades;

namespace TaskManagerAPI.Abstracciones
{
    public interface IApplicationDbContext
    {
        DbSet<global::Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TaskHistory> TaskHistories { get; set; }
        DbSet<TaskTag> TaskTags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
