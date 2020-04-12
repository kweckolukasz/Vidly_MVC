using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        //POST /api/Customers/customer
        [HttpPost]
        public void CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        //GET /api/Customers/1
        public Customer ReadCustomer(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        //PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            Customer customerDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDB == null || customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            customerDB.name = customer.name;
            customerDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerDB.membershipTypeId = customer.membershipTypeId;
            customerDB.dateOfBirth = customer.dateOfBirth;
            _context.SaveChanges();
        }
        
        //DELETE /api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer customerDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerDB);
            _context.SaveChanges();
        }
    }
}
