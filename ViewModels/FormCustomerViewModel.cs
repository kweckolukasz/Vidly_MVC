using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FormCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public CustomerDto CustomerDto { get; set; }
    }
}