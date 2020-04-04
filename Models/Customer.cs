using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Name")]
        public string name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType membershipType { get; set; }
        [Display(Name = "Membership Type Id")]
        public byte membershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        public DateTime dateOfBirth { get; set; }

        public Customer()
        {
        }

        public Customer(string name, int id)
        {
            this.name = name;
            this.Id = id;
        }
    }
}