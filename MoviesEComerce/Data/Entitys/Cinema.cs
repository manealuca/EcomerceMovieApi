using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class CinemaEntity
    {

        public int CinemaId { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string Logo { get; set; } = String.Empty;

        public string? Description { get; set; } = String.Empty;
    }
}
