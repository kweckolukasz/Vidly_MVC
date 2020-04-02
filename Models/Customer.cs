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
        public string name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType membershipType { get; set; }
        public byte membershipTypeId { get; set; }

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