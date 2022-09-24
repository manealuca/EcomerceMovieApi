using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesEComerce.Models
{
    public class OrderEntity: EntityBase
    {
        [EmailAddress(ErrorMessage ="a valid email is required")]
        public string Email { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Applicationuser User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
