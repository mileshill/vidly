using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
          //TODO: Implement Realistic Implementation
          var movies = GetMovies();
          return View(movies);
        }


        public IActionResult Details(int id)
        {
            //TODO: Implement Realistic Implementation
            var movie = GetMovies()
                .Where(m => m.Id == id)
                .SingleOrDefault();

            if(movie == null)
                return NotFound("Movie not found");

            return View(movie);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie> {
                new Movie() { Id = 1, Name = "Superman"},
                new Movie() { Id = 2, Name = "There Will Be Blood"}
            };
        }
       

    }

}