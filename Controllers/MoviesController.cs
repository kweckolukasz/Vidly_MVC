using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList();
            return View(movies);
        }

        public ActionResult Add()
        {
            FormMovieViewModel viewModel = new FormMovieViewModel
            {
                Genres = _context.Genres.ToList()
            };
            ViewBag.Header = "Add a movie";
            return View("Form", viewModel);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Header = "Edit Movie";
            Movie movie = _context.Movies
                .Include(m => m.Genre)
                .First(m => id == m.Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            FormMovieViewModel viewModel = new FormMovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };

            return View("Form", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie == null)
            {
                return HttpNotFound();
            }


            movie.DateAdded = DateTime.Now;
            movie.NumberInStock = movie.Id;

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                
                _context.SaveChanges();

            }
            else
            {
                Movie movieDB = _context.Movies.Find(movie.Id);
                if (movieDB == null)
                {
                    return HttpNotFound();
                }
                if (ModelState.IsValid)
                {
                    movieDB.Name = movie.Name;
                    movieDB.Genre = movie.Genre;
                    movieDB.GenreId = movie.GenreId;
                    movieDB.DateAdded = movie.DateAdded;
                    movieDB.ReleaseDate = movie.ReleaseDate;
                    movieDB.NumberInStock = movie.NumberInStock;
                    _context.SaveChanges();
                }


            }

            return RedirectToAction("Index", "Movies");
        }

    }
}