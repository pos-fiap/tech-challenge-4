using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechChallenge4.Domain.Entities
{
    [Table("Books")]
    public class Book(string title, string author, int genreId) : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; } = title;

        [Required]
        [MaxLength(50)]
        public required string Author { get; set; } = author;

        [Required]
        [ForeignKey("Genre")]
        public int GenreId { get; set; } = genreId;

        public virtual Genre Genre { get; set; }
    }
}
