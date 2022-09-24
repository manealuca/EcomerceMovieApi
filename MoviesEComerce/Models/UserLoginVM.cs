using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MoviesEComerce.Models
{
    public class UserLoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
