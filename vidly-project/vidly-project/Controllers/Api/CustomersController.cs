﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using vidly_project.Dtos;
using vidly_project.Models;

namespace vidly_project.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers   - To get a list of customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            // We need to map these customer objects to CustomerDto, we use link extension method then pass a delegate that
            // does the mapping

            // We now map Customer objects to CustomerDto
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/cutomers/1  - To get a single customer
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            // We are returning one customer object, so we cant use the select extension method of link.
            // We pass the customer object as an argument of this method.
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers   - Post a customer to the customer collection
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // Helper method, returns bad request result.
                return BadRequest();

            // We need to map this Dto to the domain object.
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Id is generated by the DB, so we add it to our Dto and return it to the client.
            customerDto.Id = customer.Id;

            // Call the created method, as part of RESTFul convention we return the URI of the newly created resource
            // to the client.
            // Uri(current request "/api/customers" / customer id "/10"), pass the object that was created);
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1   - Update a customer in our DB
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // pull customer from DB and check if they exist or not
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Mapping a CustomerDto to a Customer, we pass the source object and the target object
            // customerInDb is used as it is a second object that was created above and is loaded into our _context,
            // want out dbcontext to track changes in this object.
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        // DELETE /api/customers/1  - Delete a customer in our DB
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // pull customer from DB and check if they exist or not
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // this object will be marked as removed in memmory
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
