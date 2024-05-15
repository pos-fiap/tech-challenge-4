using System.ComponentModel.DataAnnotations;

namespace TechChallenge4.Application.DTOs
{
    public record BookRequestDto([Required] string Title, [Required] string Author, [Required] int GenreId);
}
