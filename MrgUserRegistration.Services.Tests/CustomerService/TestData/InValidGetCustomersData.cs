using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class InValidGetCustomersData : IEnumerable<object[]>
    {      
        private readonly IEnumerable<CustomerDto> _customers = null;

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetCustomersData(_customers);        
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
