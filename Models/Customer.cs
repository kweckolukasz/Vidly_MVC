﻿using System;
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
        public MembershipType Membershiptype { get; set; }
        [Display(Name = "Membership Type Id")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        //[Minimum18YrsOld]
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