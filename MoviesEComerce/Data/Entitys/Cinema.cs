using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class CinemaEntity: EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaId { get; set; }

        [Display(Name = "Cinema Name")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Required(ErrorMessage = "FullName is Required")]
        public string FullName { get; set; } = String.Empty;

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Profile Picture is Requiered")]
        public string Logo { get; set; } = String.Empty;
        [Display(Name = "Description")]
        [StringLength(250, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Required(ErrorMessage = "Description is Required")]
        public string? Description { get; set; } = String.Empty;

        public List<Movie>? Movies { get; set; }
    }
}
