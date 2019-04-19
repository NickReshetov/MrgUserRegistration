using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.Services.Tests.CustomerService.TestData
{
    public class InValidUpdateCustomerData : IEnumerable<object[]>
    {
        private static readonly Fixture _fixture = new Fixture();
        private readonly CustomerDto _customerWithOutPersonalNumberAndFootballTeam;
        private readonly CustomerDto _customerIsNull;
        private readonly CustomerDto _customerWithOutUniqueFields;
        private readonly CustomerDto _customerWithOutAddress;
        private readonly CustomerDto _customerWithOutInLineAddress;
        private readonly CustomerDto _customerWithOutFirstName;
        private readonly CustomerDto _customerWithOutLastName;

        public InValidUpdateCustomerData()
        {
            _customerWithOutPersonalNumberAndFootballTeam = _fixture.Create<CustomerDto>();
            _customerWithOutPersonalNumberAndFootballTeam.UniqueFields.PersonalNumber = "";
            _customerWithOutPersonalNumberAndFootballTeam.UniqueFields.FavoriteFootballTeam = "";

            _customerIsNull = null;

            _customerWithOutUniqueFields = _fixture.Create<CustomerDto>();
            _customerWithOutUniqueFields.UniqueFields = null;

            _customerWithOutAddress = _fixture.Create<CustomerDto>();
            _customerWithOutAddress.Address = null;

            _customerWithOutInLineAddress = _fixture.Create<CustomerDto>();
            _customerWithOutInLineAddress.Address.InlineAddress = "";

            _customerWithOutFirstName = _fixture.Create<CustomerDto>();
            _customerWithOutFirstName.FirstName = null;

            _customerWithOutLastName = _fixture.Create<CustomerDto>();
            _customerWithOutLastName.LastName = null;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutPersonalNumberAndFootballTeam, _customerWithOutPersonalNumberAndFootballTeam);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerIsNull, _customerIsNull);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutUniqueFields, _customerWithOutUniqueFields);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutInLineAddress, _customerWithOutInLineAddress);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutAddress, _customerWithOutAddress);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutFirstName, _customerWithOutFirstName);
            yield return CustomerTestDataHelper.GetUpdateCustomerData(_customerWithOutLastName, _customerWithOutLastName);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
