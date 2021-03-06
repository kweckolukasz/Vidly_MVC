﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.DTO;
using System.Data.Entity;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context
                .Customers
                .Include(c => c.Membershiptype)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
                
        }

        //POST /api/Customers/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.Id.ToString()), customerDto);
        }
        //GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context
                .Customers
                .Include(c => c.Membershiptype)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        //PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
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
