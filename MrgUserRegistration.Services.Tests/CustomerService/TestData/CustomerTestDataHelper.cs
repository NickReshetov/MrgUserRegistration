using System;
using System.Collections.Generic;
using MrgUserRegistration.Dtos;
using MrgUserRegistration.Services.Tests.Extensions;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public static class CustomerTestDataHelper
    {
        public static object[] GetCreateCustomerData(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            var clonedIncomigCustomer = incomingCustomer.Clone();

            if (incomingCustomer != null)
            {
                clonedIncomigCustomer.Id = Guid.Empty;
            }

            return new object[]
            {
                clonedIncomigCustomer,
                expectedCustomer
            };
        }

        public static object[] GetUpdateCustomerData(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            var clonedIncomigCustomer = incomingCustomer.Clone();

            return new object[]
            {
                clonedIncomigCustomer,
                expectedCustomer
            };
        }

        public static object[] GetUpdateCustomerCustomerIdInconsistencyData(CustomerDto incomingCustomer, CustomerDto expectedCustomer, Guid customerId)
        {
            var clonedIncomigCustomer = incomingCustomer.Clone();

            return new object[]
            {
                clonedIncomigCustomer,
                expectedCustomer,
                customerId
            };
        }

        public static object[] GetCustomersData(IEnumerable<CustomerDto> customers)
        {
            return new object[]
            {
                customers
            };
        }
    }
}
