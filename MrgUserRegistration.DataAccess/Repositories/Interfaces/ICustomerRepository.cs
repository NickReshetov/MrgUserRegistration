using System;
using System.Collections.Generic;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetCustomers();

        CustomerDto GetCustomer(Guid customerId);

        CustomerDto GetCustomer(string firstName, string lastName, AddressDto address);

        CustomerDto CreateCustomer(CustomerDto customer);

        CustomerDto UpdateCustomer(CustomerDto customer);
    }
}
