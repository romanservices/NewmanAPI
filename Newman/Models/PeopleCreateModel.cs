using System.ComponentModel.DataAnnotations;

namespace Newman.Models
{
    public class PeopleCreateModel
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        public List<string> Possessions { get; set; }
    }
}
