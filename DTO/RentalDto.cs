using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class RentalDto
    {
        public int Id { get; set; }
        [Required]
        public IEnumerable<int> MoviesIds { get; set; }
        [Required]
        public int CustomerId { get; set; }
       
    }
}