using System.ComponentModel.DataAnnotations;

namespace TechChallenge4.Application.DTOs
{
    public record GenreRequestDto([Required] string Name, string Description);
}
