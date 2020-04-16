using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FormMovieViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }
        
        [Display(Name = "Title")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "DateTime2")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Display(Name = "Stock no.")]
        [Required]
        public int? NumberInStock { get; set; }

        public string title { 
            get {
                return Id != 0 ? "new Movie" : "Edit Movie";
            } 
        }

        public FormMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        } 
        public FormMovieViewModel()
        {
            Id = 0;
        }
    }
}