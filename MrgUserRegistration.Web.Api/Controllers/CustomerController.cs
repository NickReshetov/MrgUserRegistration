using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrgUserRegistration.Dtos;
using MrgUserRegistration.Services.Interfaces;

namespace MrgUserRegistration.Web.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("customers")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customerDtos = _customerService.GetCustomers();

            return customerDtos;
        }

        [HttpPost("customer")]
        public CustomerDto CreateCustomer([FromBody]CustomerDto customer)
        {
            var customerDto = _customerService.CreateCustomer(customer);

            return customerDto;
        }

        [HttpPut("customer/{customerId:guid}")]
        public CustomerDto UpdateCustomer(Guid customerId, [FromBody]CustomerDto customer)
        {
            var customerDto = _customerService.UpdateCustomer(customerId, customer);

            return customerDto;
        }
    }
}
