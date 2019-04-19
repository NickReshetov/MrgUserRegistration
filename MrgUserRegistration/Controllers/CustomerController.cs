using System;
using System.Collections.Generic;
using MrgUserRegistration.Dtos;
using MrgUserRegistration.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MrgUserRegistration.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("api/customers")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customerDtos = _customerService.GetCustomers();

            return customerDtos;
        }

        [HttpPost("api/customer")]
        public CustomerDto CreateCustomer([FromBody]CustomerDto customer)
        {
            var customerDto = _customerService.CreateCustomer(customer);

            return customerDto;
        }

        [HttpPut("api/customer/{customerId}")]
        public CustomerDto UpdateCustomer(Guid customerId, [FromBody]CustomerDto customer)
        {
            var customerDto = _customerService.UpdateCustomer(customerId, customer);

            return customerDto;
        }
    }
}
