using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesEComerce.Models
{
    public class ActorEntity: EntityBase
    {
        public int ActorId { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public virtual List<MovieActor>? MovieActor { get; set; }

    }
}
