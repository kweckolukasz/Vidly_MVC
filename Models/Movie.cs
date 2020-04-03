using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime dateAdded { get; set; }
        public int numberInStock { get; set; }

        public Movie()
        {
            dateAdded = DateTime.Now;
        }

    }

}