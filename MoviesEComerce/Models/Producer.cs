using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class Producer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProducerId { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Profile Picture")]
        public string PictureURL { get; set; } = String.Empty;
        [Display(Name = "Biography")]
        public string? Bio { get; set; } = String.Empty;

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
