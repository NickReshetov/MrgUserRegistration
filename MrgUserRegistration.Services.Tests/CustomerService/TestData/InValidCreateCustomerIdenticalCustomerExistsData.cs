using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class InValidCreateCustomerIdenticalCustomerExistsData : IEnumerable<object[]>
    {
        private static readonly Fixture _fixture = new Fixture();
        private readonly CustomerDto _validCustomer;

        public InValidCreateCustomerIdenticalCustomerExistsData()
        {
            _validCustomer = _fixture.Create<CustomerDto>();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetCreateCustomerData(_validCustomer, _validCustomer);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
