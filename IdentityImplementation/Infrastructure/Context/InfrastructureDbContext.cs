using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public interface IInfrastructureDbContext
    {
        public IList<Products> Products { get; set; }
    }

    public class InfrastructureDbContext : DbContext, IInfrastructureDbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public InfrastructureDbContext(string connectionString, string migrationAssemblyName)
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
            builder.Entity<Products>()
                   .HasKey(x => x.Id);
        }

        public IList<Products> Products { get; set; }
    }
}
