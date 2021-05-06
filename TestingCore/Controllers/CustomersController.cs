using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingCore.Data;
using TestingCore.Models;
using TestingCore.DTO;
using Microsoft.AspNetCore.Http.Extensions;

namespace TestingCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly TestingCoreContext _context;
        private readonly IMapper _mapper;

        public CustomersController(TestingCoreContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDTO>);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Customer, CustomerDTO>(customerInDb));
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Customer customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;


            return CreatedAtAction(nameof(GetCustomer), new { Id = customer.Id }, customerDTO);

            //return Ok(customerDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateCustomer(int Id, CustomerDTO customerDTO)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _mapper.Map(customerDTO, customerInDb);
            _context.SaveChanges();

            return Ok("The record was updated successfully!");
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Remove(customerInDb);
            _context.SaveChanges();
            return Ok("The record was deleted successfully!");
        }
    }
}
