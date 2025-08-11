using Activities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Activities.Repository
{
    public class DataContext : DbContext
    {
        private readonly ConnectionStringOptions ConnectionStringOptions;

        public DataContext(IOptions<ConnectionStringOptions> options)
        {
            ConnectionStringOptions = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStringOptions.ConnectionSpi);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
