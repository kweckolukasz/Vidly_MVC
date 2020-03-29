using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieCustomerViewModel
    {
        public MovieCustomerViewModel()
        {
            this.customers = new List<Customer>
            {
                new Customer("Customer 1", 0),
                new Customer("Customer 2", 1),
                new Customer("Customer 3", 2),
                new Customer("Customer 4", 3)
            };
            this.movies = new List<Movie>
            {
                new Movie("Shrek"),
                new Movie("Terminator"),
                new Movie("Harold and Kumar escape from Guantanamo bay")

            };
        }

        public List<Movie> movies { get; set; }

        public List<Customer> customers { get; set; }
    }
}