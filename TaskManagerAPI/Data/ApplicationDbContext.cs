using Entidades;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<Entidades.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones de las entidades
            modelBuilder.Entity<Entidades.Task>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id).HasColumnName("id");
                entity.Property(u => u.Username).HasColumnName("username");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.PasswordHash).HasColumnName("password_hash");
                entity.Property(u => u.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Id);
            });

            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.HasKey(th => th.Id);
                entity.Property(th => th.ChangeDate).HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(th => th.Task)
                      .WithMany(t => t.History)
                      .HasForeignKey(th => th.TaskId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(th => th.ChangedByUser)
                      .WithMany(u => u.TaskHistories)
                      .HasForeignKey(th => th.ChangedBy)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TaskTag>(entity =>
            {
                entity.HasKey(tt => new { tt.TaskId, tt.TagId });

                entity.HasOne(tt => tt.Task)
                    .WithMany()  // no colección en Task
                    .HasForeignKey(tt => tt.TaskId);

                entity.HasOne(tt => tt.Tag)
                    .WithMany()  // no colección en Tag
                    .HasForeignKey(tt => tt.TagId);
            });

        }
    }
}
