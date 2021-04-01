using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EFCoreDemo.Models;
using EFCoreDemo.Services;


namespace EFCoreDemo.Controllers
{  
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase    
    {  
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService  customerService)
        {
           _CustomerService = customerService;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
           return _CustomerService.GetCustomers(); 
        }

        [HttpGet("{id}")]
        public  Customer  Get(int id)
        {
           return _CustomerService.GetCustomer(id); 
        }

        [HttpPost()]
        public void Post([FromBody] Customer newCustomer)
        {
            _CustomerService.AddCustomer(newCustomer);            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            try
            {
                _CustomerService.UpdateCustomer(id, updatedCustomer);
                return Accepted();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                return base.BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _CustomerService.DeleteCustomer(id);
                return base.Accepted();
            }
            catch (ArgumentException exception)
            {

                return base.BadRequest(exception.Message);
            }
        }

    }
}