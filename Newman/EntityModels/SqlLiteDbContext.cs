using Microsoft.EntityFrameworkCore;
using Newman.EntityModels.Models;

namespace Newman.EntityModels
{
    public class SqlLiteDbContext : DbContext
    {
        public DbContextOptions<SqlLiteDbContext> Options { get; }
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
        {
            Options = options;
            var root = new DirectoryInfo(Environment.CurrentDirectory).Parent?.FullName;
            DbPath = System.IO.Path.Join($"{root}/newman", "newman.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        public DbSet<People> Persons { get; set; }
        public DbSet<Possession> Possessions { get; set; }
        public string DbPath { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            People.BuildModel(modelBuilder);
        }
            
    }
}
