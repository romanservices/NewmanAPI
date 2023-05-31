using System.ComponentModel.DataAnnotations;

namespace Newman.Models
{
    public class PeopleUpdateModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
    }
}
