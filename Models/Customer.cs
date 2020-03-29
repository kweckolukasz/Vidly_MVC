using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }

        public Customer()
        {
        }

        public Customer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}