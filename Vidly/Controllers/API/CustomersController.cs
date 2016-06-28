using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
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
        //GET /API/customers
        /// <summary>
        /// Returns all customer that marches with query param
        /// </summary>
        /// <param name="query">This the customer name sended by the front-end</param>
        /// <returns></returns>
        public IHttpActionResult GetCustomers(string query = null)
        {

            //eagger loading to return hierarchical data (MembershipType)
            /*
             * This method will return a json object like this
             * [
                    {
                        "id": 9,
                        "name": "Rosa",
                        "birthdate": "1987-11-24T00:00:00",
                        "isSubscribedToNewsletter": true,
                        "membershipTypeId": 3,
                        "membershipType": {
                            "id": 3,
                            "name": "Quarterly"
                        }
                    }
                ]
             */
            //get customers and memberships using egger loading
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            //modify the query to filter by query parameter
            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            //map the object and convert toList
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);

            return Ok(customerDtos);
        }
        //GET /API/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        //POST /API/customers
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
            //return the id was inserted into the DB
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/"+customer.Id), customerDto);
        }
        //PUT /API/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthdate = customerDto.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();
        }
        //DELETE/API/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
