using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.SqlClient;

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
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult Add()
        {
            return View("Form");
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.First(m =>id == m.id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View("Form", movie);
        }
        public ActionResult Save(Movie movie)
        {
            movie.dateAdded = DateTime.Now;
            movie.numberInStock = movie.id;

            if (movie.id == 0)
            {
                _context.Movies.Add(movie);
                
                _context.SaveChanges();

            }
            else
            {
                Movie movieDB = _context.Movies.Find(movie.id);
                if (movieDB == null)
                {
                    return HttpNotFound();
                }
                if (ModelState.IsValid)
                {
                    movieDB.name = movie.name;
                    movieDB.genre = movie.genre;
                    movieDB.dateAdded = movie.dateAdded;
                    movieDB.releaseDate = movie.releaseDate;
                    movieDB.numberInStock = movie.numberInStock;
                    _context.SaveChanges();
                }


            }

            return RedirectToAction("Index", "Movies");
        }

    }
}