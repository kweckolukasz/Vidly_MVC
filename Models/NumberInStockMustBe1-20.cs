using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NumberInStockMustBe1_20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie =(Movie) validationContext.ObjectInstance;
            var num = (int)movie.NumberInStock;

            return (num >= 1 && num <= 20) ? ValidationResult.Success
                : new ValidationResult("number in stock must be in 1-20 range"); 
        }
    }

}