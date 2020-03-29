using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {

        MovieCustomerViewModel viewModel = new MovieCustomerViewModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            ViewBag.Message = "List of movies.";
            return View(viewModel);
        }

        public ActionResult Customers()
        {
            ViewBag.Message = "list of Customers.";
            return View(viewModel);
        }

        
        public ActionResult CustomerDetail(int id)
        {
            if (id>viewModel.customers.Count-1)
            {
                return HttpNotFound();
            }
            Customer customer = viewModel.customers[id];
            return View(customer);
        }
    }
}