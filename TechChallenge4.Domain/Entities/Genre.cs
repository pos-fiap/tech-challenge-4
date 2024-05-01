using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechChallenge4.Domain.Entities
{
    [Table("Genres")]
    public class Genre : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;


        public Genre() { }

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
