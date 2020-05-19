using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }

        [Range(1,20)]
        public int NumberInStock { get; set; }
        public int avaibleCopies { get; set; }
    }
}