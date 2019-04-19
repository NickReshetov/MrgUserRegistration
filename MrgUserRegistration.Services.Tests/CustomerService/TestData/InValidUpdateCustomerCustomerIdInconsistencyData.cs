using System;
using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class InValidUpdateCustomerCustomerIdInconsistencyData : IEnumerable<object[]>
    {
        private static readonly Fixture _fixture = new Fixture();
        private readonly CustomerDto _customer1 = _fixture.Create<CustomerDto>();
        private readonly CustomerDto _customer2 = _fixture.Create<CustomerDto>();
        private readonly CustomerDto _customer3 = _fixture.Create<CustomerDto>();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetUpdateCustomerCustomerIdInconsistencyData(_customer1, _customer1, Guid.Empty);
            yield return CustomerTestDataHelper.GetUpdateCustomerCustomerIdInconsistencyData(_customer2, _customer2, Guid.NewGuid());
            yield return CustomerTestDataHelper.GetUpdateCustomerCustomerIdInconsistencyData(_customer3, _customer3, Guid.NewGuid());
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
