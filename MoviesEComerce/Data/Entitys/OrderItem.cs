using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MoviesEComerce.Models
{
    public class OrderItemEntity: EntityBase
    {
        public int Ammount { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is Required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be greater tan 0")]
        [Range(0, 9999999999999999.99)]
        public double Price { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
