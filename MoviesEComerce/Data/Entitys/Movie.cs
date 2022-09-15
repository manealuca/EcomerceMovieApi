using MoviesEComerce.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesEComerce.Models
{
    public class MovieEntity
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }

        public string MovieDescription { get; set; } = String.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string MovieImageUrl { get; set; }


        //Relationships
 
        public int CinemaId { get; set; }
        public Cinema cinema { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public int ProducerId { get; set; }
        public Producer MovieProducer { get; set; }


    }
}
