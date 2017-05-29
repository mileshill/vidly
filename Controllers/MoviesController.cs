using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext context;

        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;

        }
        // GET: Movies
        public ViewResult Index()
        {
            //TODO: Implement Realistic Implementation
            var movies = context.Movies;
          return View(movies);
        }


        public IActionResult Details(int id)
        {
            //TODO: Implement Realistic Implementation
            var movie = context.Movies
                .Where(m => m.Id == id)
                .SingleOrDefault();

            if (movie == null)
                return NotFound("Movie not found");

            return View(movie);
        }
    }

}