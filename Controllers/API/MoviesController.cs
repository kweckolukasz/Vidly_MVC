using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //POST Movies/Movie
        [HttpPost]
        public IHttpActionResult createMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var MovieToDB = Mapper.Map<MovieDTO, Movie>(movieDto);
            _context.Movies.Add(MovieToDB);
            _context.SaveChanges();
            movieDto.Id = MovieToDB.Id;
            return Created(new Uri(Request.RequestUri+"/"+MovieToDB.Id),movieDto);
        }

        //GET Movies
        public IHttpActionResult getMovies()
        {
            var Movies = _context.Movies.ToList();
            var MoviesDtos = Mapper.Map<List<Movie>, List<MovieDTO>>(Movies);
            return Ok(MoviesDtos);
        }

        //GET Movies/1
        public IHttpActionResult getMovie(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }
            var MovieDto = Mapper.Map<Movie, MovieDTO>(Movie);
            return Ok(MovieDto);
        }

        //PUT Movies/movies
        [HttpPut]
        public IHttpActionResult editMovie(MovieDTO movieDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieToEdit = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieToEdit == null)
                return NotFound();

            Mapper.Map(movieDto, movieToEdit);
            _context.SaveChanges();
            return Ok();

        }

        //DELETE Mmovies/id
        [HttpPost]
        public IHttpActionResult deleteMovie(int id)
        {
            var MovieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieToDelete == null)
                return NotFound();

            _context.Movies.Remove(MovieToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}