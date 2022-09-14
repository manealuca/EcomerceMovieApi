using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;

namespace MoviesEComerce.Controllers
{
    public class CinemaController : Controller
    {
        private readonly MovieComerceContext _context;

        public CinemaController(MovieComerceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Cinemas = _context.Cinema.ToListAsync();

            return View(Cinemas);
        }
    }
}
