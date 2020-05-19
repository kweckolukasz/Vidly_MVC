using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
    private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {
            var Customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            
            var Movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();
            foreach (var movie in Movies)
            {
                if (movie.AvaibleCopies==0)
                {
                    return BadRequest("Error, no avaible copies left");
                }
                movie.AvaibleCopies--;
                Rental rental = new Rental()
                {
                    Customer = Customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.NewRentals.Add(rental);
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        public List<Rental> GetRentals()
        {
            return _context.NewRentals.ToList();
        }
    }
}