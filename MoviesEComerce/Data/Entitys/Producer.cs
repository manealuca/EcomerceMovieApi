using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class ProducerEntity
    {

        public int ProducerId { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string PictureURL { get; set; } = String.Empty;

        public string? Bio { get; set; } = String.Empty;

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
