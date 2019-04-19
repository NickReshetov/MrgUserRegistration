using System;
using System.Collections.Generic;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers();

        CustomerDto CreateCustomer(CustomerDto customer);

        CustomerDto UpdateCustomer(Guid customerId, CustomerDto customer);
    }
}