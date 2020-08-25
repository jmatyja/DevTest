using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await customerService.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await customerService.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreate createCustomer)
        {
            (var isValid, var validationMessages) = createCustomer.Validate();
            if (!isValid)
            {
                return BadRequest(string.Join(", ", validationMessages));
            }
            
            var createdCustomer = await customerService.CreateCustomerAsync(createCustomer);

            return Created($"customer/{createdCustomer.Id}", createdCustomer);
        }
    }
}