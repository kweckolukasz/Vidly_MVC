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
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult EditCustomer(int id)
        {
            var ViewModel = new FormCustomerViewModel();
            var Customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            var MemberShipTypes = _context.MembershipTypes.ToList();
            ViewModel.Customer = Customer;
            ViewModel.MembershipTypes = MemberShipTypes;
            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                /*var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, Customer>());
                IMapper mapper = config.CreateMapper();
                customerInDB = mapper.Map<Customer, Customer>(customer);*/
                CustomerInDB.name = customer.name;
                CustomerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDB.membershipTypeId = customer.membershipTypeId;
                CustomerInDB.dateOfBirth = customer.dateOfBirth;

                TryUpdateModel(CustomerInDB);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}