using MoviesEComerce.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesEComerce.Models
{
    public class MovieEntity: EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Movie Description is Required")]
        [StringLength(250, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string MovieDescription { get; set; } = String.Empty;

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is Required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be greater tan 0")]
        [Range(0, 9999999999999999.99)]
        public double Price { get; set; }

        [Display(Name = "Movie Image")]
        [Required(ErrorMessage = "Profile Picture is Requiered")]
        public string MovieImageUrl { get; set; }


        //Relationships
        [Display(Name ="Cinema")]
        public int? CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema? cinema { get; set; }


        public List<MovieActor>? MovieActors { get; set; }
        public MovieCategory? MovieCategory { get; set; }

        [Display(Name = "Producer")]
        public int? ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer? MovieProducer { get; set; }



    }
}
