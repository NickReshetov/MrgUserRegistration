using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class ValidUpdateCustomerData : IEnumerable<object[]>
    {
        private static readonly Fixture _fixture = new Fixture();
        private readonly CustomerDto _customer1 = _fixture.Create<CustomerDto>();
        private readonly CustomerDto _customer2 = _fixture.Create<CustomerDto>();
        private readonly CustomerDto _customer3 = _fixture.Create<CustomerDto>();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customer1, _customer1);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customer2, _customer2);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customer3, _customer3);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
