using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.ViewModels;
using Vidly.Models;
using AutoMapper;
using Vidly.DTO;

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
        [Route("Customers")]
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.Membershiptype).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return View(customerDto);
        }

        public ActionResult newCustomer()
        {
            ViewBag.Heading = "New Customer";
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                CustomerDto = new CustomerDto(),
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
            ViewModel.CustomerDto = Mapper.Map<Customer, CustomerDto>(Customer);
            ViewModel.MembershipTypes = MemberShipTypes;
            return View("CustomerForm", ViewModel);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return HttpNotFound();
            }
            if (!ModelState.IsValid)
            {
                var ViewModel = new FormCustomerViewModel
                {
                    CustomerDto = new CustomerDto(),
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
               
            }
            if (customerDto.Id == 0)
                _context.Customers.Add(Mapper.Map<CustomerDto, Customer>(customerDto));
            else
            {
                var CustomerInDB = _context.Customers.Single(c => c.Id == customerDto.Id);
                Mapper.Map(customerDto, CustomerInDB);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}