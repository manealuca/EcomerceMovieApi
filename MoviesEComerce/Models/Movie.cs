using MoviesEComerce.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesEComerce.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string MovieDescription { get; set; } = String.Empty;
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Movie Image")]
        public string MovieImageUrl { get; set; }


        //Relationships
 
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema cinema { get; set; }
        [JsonIgnore]
        public List<MovieActor> MovieActors { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer MovieProducer { get; set; }


    }
}
