using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.DTO;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }


        //POST /api/Customers/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.Id.ToString()), customerDto);
        }
        //GET /api/Customers/1
        public IHttpActionResult ReadCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            Customer customerDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDB == null || customerDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Mapper.Map(customerDto, customerDB);
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
