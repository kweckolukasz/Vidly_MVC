using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Minimum18YrsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;

            if (Customer.MembershipTypeId == MembershipType.UnAssigned || Customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (Customer.dateOfBirth == null)
                return new ValidationResult("Birthdate is requied field");

            var age = DateTime.Now.Year - Customer.dateOfBirth.Year;

            return (age >= 18) ?
                ValidationResult.Success 
                : new ValidationResult("Customer have to have at least 18 years old to have a membership");
            
        }
    }
}