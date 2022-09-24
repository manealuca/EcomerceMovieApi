using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoviesEComerce.Models
{
    public class Applicationuser:IdentityUser
    {
        [Display(Name ="FullName")]
        public string FullName { get; set; }
    }
}
