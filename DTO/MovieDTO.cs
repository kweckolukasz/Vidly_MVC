﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Column(TypeName = "DateTime2")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        //[NumberInStockMustBe1_20]
        public int NumberInStock { get; set; }
    }
}