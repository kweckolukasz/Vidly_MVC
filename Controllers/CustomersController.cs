using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.ViewModels;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.membershipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerDetail(int id)
        {
            var customer = _context.Customers.Include(c => c.membershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult newCustomer()
        {
            ViewBag.Heading = "New Customer";
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult EditCustomer(int id)
        {
            ViewBag.Heading = "Edit Customer";
            var ViewModel = new FormCustomerViewModel();
            var MemberShipTypes = _context.MembershipTypes.ToList();
            var Customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            ViewModel.Customer = Customer;
            ViewModel.MembershipTypes = MemberShipTypes;
            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                var ViewModel = new FormCustomerViewModel
                {
                    Customer = new Customer(),
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
               
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                CustomerInDB.name = customer.name;
                CustomerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDB.membershipTypeId = customer.membershipTypeId;
                CustomerInDB.dateOfBirth = customer.dateOfBirth;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}