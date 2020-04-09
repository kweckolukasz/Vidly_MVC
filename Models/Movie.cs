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
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Date added")]
        [Column(TypeName = "DateTime2")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Stock no.")]
        public int NumberInStock { get; set; }
    }
}