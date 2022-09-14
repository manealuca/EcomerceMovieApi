using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;

namespace MoviesEComerce.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieComerceContext _context;

        public MovieController(MovieComerceContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var Movies = _context.Movie.Include(m=>m.cinema).ToListAsync();
            return View(Movies);
        }
    }
}
