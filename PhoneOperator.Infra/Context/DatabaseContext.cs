using System;
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
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var name = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
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