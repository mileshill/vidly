using Microsoft.AspNetCore.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public IActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek" };

            return View(movie);
            
        }
    }
}