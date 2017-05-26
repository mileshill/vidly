using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public IActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek" };

            var customers = new List<Customer>()
            {
                new Customer() {Name = "Miles"},
                new Customer() {Name = "Scott"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello World");
            //return NotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);    
        }

        // /movies
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
                pageIndex = 1;
            
            if(string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        
        [Route("[controller]/[action]/{year:min(1900)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("year={0}&month={1}", year, month));
        }

    }

}