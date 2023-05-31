using Microsoft.EntityFrameworkCore;
using Newman.EntityModels.Models;

namespace Newman.EntityModels
{
    public class NewmanContext : DbContext
    {
        public DbContextOptions<NewmanContext> Options { get; }
        public NewmanContext(DbContextOptions<NewmanContext> options) : base(options)
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
