using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class ValidGetCustomersData : IEnumerable<object[]>
    {
        private static readonly Fixture _fixture = new Fixture();
        private static readonly CustomerDto _customer1 = _fixture.Create<CustomerDto>();
        private static readonly CustomerDto _customer2 = _fixture.Create<CustomerDto>();
        private static readonly CustomerDto _customer3 = _fixture.Create<CustomerDto>();
        private readonly IEnumerable<CustomerDto> _customers = new List<CustomerDto> { _customer1, _customer2, _customer3 };

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetCustomersData(_customers);        
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
