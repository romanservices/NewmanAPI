using Microsoft.EntityFrameworkCore;

namespace Newman.EntityModels.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Possession> Possessions { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasMany(s => s.Possessions).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
