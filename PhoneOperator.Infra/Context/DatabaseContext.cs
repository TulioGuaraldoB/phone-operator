using Microsoft.EntityFrameworkCore;
using PhoneOperator.Domain.Models;

namespace PhoneOperator.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Operator> Operators { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var host = "127.0.0.1";
            var name = "teste";
            var user = "teste";
            var password = "teste";
            var dsn = $"server={host}; database={name}; user={user}; password={password}";
            options.UseMySql(dsn, ServerVersion.AutoDetect(dsn));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operator>().
            HasKey(o => o.Id);
        }
    }
}