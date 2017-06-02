using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.API
{
    
  [Route("/api/[controller]")]
  public class MoviesController : Controller
  {

    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public MoviesController(ApplicationDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }


    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetMovies()
    {
      var movies = await context.Movies.ToListAsync();

      return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(movies);
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<IActionResult> GetMovie(int id)
    {
      // var customer = await context.Customers
      //     .SingleOrDefault(c => c.Id == id);

      var movie = await context.Movies
          .SingleOrDefaultAsync(m => m.Id == id);


      if (movie == null)
        return NotFound();

      
      return Ok(mapper.Map<Movie, MovieDto>(movie));
    }


    [HttpPost]
    public async Task<IActionResult> NewMovie([FromBody] MovieDto movieDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var movie = mapper.Map<MovieDto, Movie>(movieDto);
      movie.Added = DateTime.Now;
      context.Movies.Add(movie);
      context.SaveChanges();

      movieDto.Added = movie.Added;
      movieDto.Id = movie.Id;
      return Ok(movieDto);
    }

    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var movieInDb = await context.Movies
        .SingleOrDefaultAsync(m => m.Id == id);


      if (movieInDb == null)
        return NotFound();


      mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

      context.SaveChanges();

      mapper.Map<Movie, MovieDto>(movieInDb, movieDto);

      return Ok(movieDto);
    }

    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id)
    {
      var movie = await context.Movies
        .SingleOrDefaultAsync(m => m.Id == id);

      if (movie == null)
        return NotFound();

      context.Remove(movie);
      context.SaveChanges();
      return Ok();
    }

  }
}