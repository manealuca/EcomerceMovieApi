using System.ComponentModel.DataAnnotations;

namespace MoviesEComerce.Models
{

        public class ShoppingCartItemEntity:EntityBase
        {

        public Movie Movie { get; set; }
        [Display(Name = "Ammount")]
        [Range(0, 9999999999999999)]
        public int Amount { get; set; }


            public string ShoppingCartId { get; set; }
        }
    
}
