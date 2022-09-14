using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;

namespace MoviesEComerce.Controllers
{
    public class ProducerController : Controller
    {
        private readonly MovieComerceContext _context;

        public ProducerController(MovieComerceContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {
            var db = await _context.Producer.ToListAsync();

            return View();
        }
    }
}
