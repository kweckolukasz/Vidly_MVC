using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.DTO;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]
        //[Minimum18YrsOld]
        public DateTime dateOfBirth { get; set; }

    }
}