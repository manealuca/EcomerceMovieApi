using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesEComerce.Models
{
    public class Cinema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaId { get; set; }

        [Required]
        [Display(Name ="Cinema Name")]
        public string FullName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; } = String.Empty;
        [Display(Name = "Description")]
        public string? Description { get; set; } = String.Empty;
    }
}
