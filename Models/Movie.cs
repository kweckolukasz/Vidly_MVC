using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Display(Name = "Title")]
        public string name { get; set; }
        [Display(Name = "Genre")]
        public string genre { get; set; }
        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime releaseDate { get; set; }
        [Display(Name = "Date added")]
        [Column(TypeName = "DateTime2")]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Stock no.")]
        public int numberInStock { get; set; }
    }
}