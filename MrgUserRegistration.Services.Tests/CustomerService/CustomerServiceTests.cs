using System;
using System.Collections.Generic;
using Moq;
using MrgUserRegistration.DataAccess.Repositories.Interfaces;
using MrgUserRegistration.Dtos;
using MrgUserRegistration.Services.Exceptions;
using MrgUserRegistration.Services.Interfaces;
using MrgUserRegistration.Services.Tests.CustomerService.TestData;
using Newtonsoft.Json;
using Xunit;

namespace MrgUserRegistration.Services.Tests.CustomerService
{
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository = new Mock<ICustomerRepository>();
        
        [Theory]
        [ClassData(typeof(ValidGetCustomersData))]
        public void GetCustomers_CustomersHasBeenGotten(IEnumerable<CustomerDto> expectedCustomers)
        {
            SetupGetCustomers(expectedCustomers);

            var customers = _customerService.GetCustomers();

            var serializedCustomers = JsonConvert.SerializeObject(customers);

            var serializedExpectedCustomers = JsonConvert.SerializeObject(expectedCustomers);

            Assert.Equal(serializedExpectedCustomers, serializedCustomers);
        }

        [Theory]
        [ClassData(typeof(InValidGetCustomersData))]
        public void GetCustomers_CustomersHasNotBeenGotten(IEnumerable<CustomerDto> expectedCustomers)
        {
            SetupGetCustomers(expectedCustomers);

            IEnumerable<CustomerDto> GetCustomers() => _customerService.GetCustomers();

            Assert.Throws<GetCustomersException>(GetCustomers);
        }
        
        [Theory]
        [ClassData(typeof(ValidCreateCustomerData))]
        public void CreateCustomer_CustomerHasBeenCreated(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            SetupCreateCustomer(incomingCustomer, expectedCustomer, null);

            var customer = _customerService.CreateCustomer(incomingCustomer);

            var serializedCustomer = JsonConvert.SerializeObject(customer);

            var serializedExpectedCustomer = JsonConvert.SerializeObject(expectedCustomer);

            Assert.Equal(serializedExpectedCustomer, serializedCustomer);
        }

        [Theory]
        [ClassData(typeof(InValidCreateCustomerData))]
        public void CreateCustomer_CustomerHasNotBeenCreated(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            SetupCreateCustomer(incomingCustomer, expectedCustomer, null);

            CustomerDto CreateCustomer() => _customerService.CreateCustomer(incomingCustomer);

            Assert.Throws<CreateCustomerException>(CreateCustomer);
        }     

        [Theory]
        [ClassData(typeof(InValidCreateCustomerIdenticalCustomerExistsData))]
        public void CreateCustomer_CustomerHasNotBeenCreated_IdenticalCustomerExists(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            var existingCustomer = new CustomerDto
            {
                FirstName = incomingCustomer?.FirstName,
                LastName = incomingCustomer?.LastName,
                Address = incomingCustomer?.Address
            };

            SetupCreateCustomer(incomingCustomer, expectedCustomer, existingCustomer);

            CustomerDto CreateCustomer() => _customerService.CreateCustomer(incomingCustomer);

            Assert.Throws<CreateCustomerException>(CreateCustomer);
        }
        
        [Theory]
        [ClassData(typeof(ValidUpdateCustomerData))]
        public void UpdateCustomer_CustomerHasBeenUpdated(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            SetupUpdateCustomer(incomingCustomer, expectedCustomer);

            var customer = _customerService.UpdateCustomer(incomingCustomer.Id, incomingCustomer);

            var serializedCustomer = JsonConvert.SerializeObject(customer);

            var serializedExpectedCustomer = JsonConvert.SerializeObject(expectedCustomer);

            Assert.Equal(serializedExpectedCustomer, serializedCustomer);
        }

        [Theory]
        [ClassData(typeof(InValidUpdateCustomerData))]
        public void UpdateCustomer_CustomerHasNotBeenUpdated(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            SetupUpdateCustomer(incomingCustomer, expectedCustomer);

            var customerId = incomingCustomer?.Id ?? Guid.NewGuid();

            CustomerDto UpdateCustomer() => _customerService.UpdateCustomer(customerId, incomingCustomer);

            Assert.Throws<UpdateCustomerException>(UpdateCustomer);
        }

        [Theory]
        [ClassData(typeof(InValidUpdateCustomerCustomerIdInconsistencyData))]
        public void UpdateCustomer_CustomerHasNotBeenUpdated_CustomerIdInconsistency(CustomerDto incomingCustomer, CustomerDto expectedCustomer, Guid customerId)
        {
            SetupUpdateCustomer(incomingCustomer, expectedCustomer);

            CustomerDto UpdateCustomer() => _customerService.UpdateCustomer(customerId, incomingCustomer);

            Assert.Throws<UpdateCustomerException>(UpdateCustomer);
        }

        private void SetupGetCustomers(IEnumerable<CustomerDto> expectedCustomers)
        {
            _mockCustomerRepository
                .Setup(m => m.GetCustomers())
                .Returns(expectedCustomers);

            _customerService = new Services.CustomerService(_mockCustomerRepository.Object);
        }

        private void SetupCreateCustomer(CustomerDto incomingCustomer, CustomerDto expectedCustomer, CustomerDto existingCustomer)
        {
            _mockCustomerRepository
                .Setup(m => m.GetCustomer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AddressDto>()))
                .Returns(existingCustomer);

            if (incomingCustomer != null)
                incomingCustomer.Id = expectedCustomer.Id;

            _mockCustomerRepository
                .Setup(m => m.CreateCustomer(It.IsAny<CustomerDto>()))
                .Returns(incomingCustomer);

            _customerService = new Services.CustomerService(_mockCustomerRepository.Object);
        }

        private void SetupUpdateCustomer(CustomerDto incomingCustomer, CustomerDto expectedCustomer)
        {
            _mockCustomerRepository
                .Setup(m => m.GetCustomer(It.IsAny<Guid>()))
                .Returns(expectedCustomer);

            _mockCustomerRepository
                .Setup(m => m.UpdateCustomer(It.IsAny<CustomerDto>()))
                .Returns(incomingCustomer);

            _customerService = new Services.CustomerService(_mockCustomerRepository.Object);
        }
    }   
}
