using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public interface IWorkerContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<StockExchange> StockExchanges { get; set; }
    }

    public class WorkerContext : DbContext, IWorkerContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public WorkerContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasKey(e => e.Id);

            builder.Entity<StockExchange>()
                .HasOne(e => e.Company)
                .WithMany(e => e.StockExchanges)
                .HasForeignKey(e => e.CompanyId);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<StockExchange> StockExchanges { get; set; }
    }
}
