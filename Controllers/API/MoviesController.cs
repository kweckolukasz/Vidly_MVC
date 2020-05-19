using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context
                .Movies
                .Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        //POST Movies/Movie
        [HttpPost]
        [Authorize(Roles = UserRoles.CanManageMovies)]
        public IHttpActionResult createMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var MovieToDB = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(MovieToDB);
            _context.SaveChanges();
            movieDto.Id = MovieToDB.Id;
            return Created(new Uri(Request.RequestUri+"/"+MovieToDB.Id),movieDto);
        }


        //GET Movies/1
        public IHttpActionResult getMovie(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }
            var MovieDto = Mapper.Map<Movie, MovieDto>(Movie);
            return Ok(MovieDto);
        }

        //PUT Movies/movies
        [HttpPut]
        [Authorize(Roles = UserRoles.CanManageMovies)]
        public IHttpActionResult editMovie(MovieDto movieDto, int id)
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
        [Authorize(Roles = UserRoles.CanManageMovies)]
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