using System;
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


        public IActionResult Edit(int? id)
        {

            
            //TODO: Implement Realistic Implementation
            var movie = context.Movies
                .Where(m => m.Id == id)
                .SingleOrDefault();

            if (movie == null)
                return NotFound("Movie not found");

            var viewModel = new MovieFormViewModel()
            {
                Genres = context.Movies.Select(m => m.Genre).Distinct().ToList(),
                Movie = movie

            };
            return View("MovieForm", viewModel);
        }

        public IActionResult New()
        {
          var genres = context.Movies
            .Select(m => m.Genre)
            .Distinct()
            .ToList();

          var viewModel = new MovieFormViewModel()
          {
            Genres = genres,
            Movie = new Movie()
          };

          //TODO: Implement Realistic Implementation
          return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = context.Movies.Select(m => m.Genre).Distinct().ToList()
                };
                return View("MovieForm", viewModel);
            }

          if(movie.Id == 0)
          {
              movie.Added = DateTime.Now;
              context.Movies.Add(movie);
          }
          else
          {
            var movieInDb = context.Movies.Single(m => m.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.Genre = movie.Genre;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.Added = movie.Added;
            movieInDb.NumberInStock = movie.NumberInStock;
          }
          context.SaveChanges();
          
          return RedirectToAction("Index", "Movies");
        }
    }

}