using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class ApplicationContext : DbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Movie> Movies { get; set; }
    }
}