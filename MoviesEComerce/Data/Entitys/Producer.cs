using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class ProducerEntity:EntityBase
    {

        public int ProducerId { get; set; }

        [Display(Name = "FullName")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; } = String.Empty;
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is Requiered")]
        public string PictureURL { get; set; } = String.Empty;
        [Display(Name = "Biography")]
        [StringLength(250, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Required(ErrorMessage = "Biography is Required")]
        public string? Bio { get; set; } = String.Empty;

        //Relationships

        public List<Movie>? Movies { get; set; }
    }
}
