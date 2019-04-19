using System;
using System.Collections.Generic;
using System.Linq;
using MrgUserRegistration.DataAccess.Repositories.Interfaces;
using MrgUserRegistration.Dtos;
using MrgUserRegistration.Services.Exceptions;
using MrgUserRegistration.Services.Interfaces;

namespace MrgUserRegistration.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _customerRepository
                ?.GetCustomers()
                ?.ToList();

            ValidateCustomers(customers);

            return customers;
        }        

        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            ValidateCreatingCustomer(customer);

            var createdCustomer = _customerRepository.CreateCustomer(customer);

            return createdCustomer;
        }

        public CustomerDto UpdateCustomer(Guid customerId, CustomerDto customer)
        {
            ValidateUpdatingCustomer(customerId, customer);

            var updatedCustomer = _customerRepository.UpdateCustomer(customer);

            return updatedCustomer;
        }

        private static void ValidateCustomers(IEnumerable<CustomerDto> customers)
        {
            if (customers == null)
                throw new GetCustomersException("Customers collection is null");
        }

        private void ValidateCreatingCustomer(CustomerDto customer)
        {
            ValidateCustomer<CreateCustomerException>(customer);

            var existingCustomer = _customerRepository.GetCustomer(customer.FirstName, customer.LastName, customer.Address);

            if (existingCustomer != null)
                throw new CreateCustomerException($"Customer with " +
                                                  $"FirstName: {customer.FirstName}, " +
                                                  $"LastName: {customer.LastName}, " +
                                                  $"Address: {customer.Address.InlineAddress}, already exists, create failed!");
        }

        private void ValidateUpdatingCustomer(Guid customerId, CustomerDto customer)
        {
            ValidateCustomer<UpdateCustomerException>(customer);

            if (customerId != customer.Id)
                throw new UpdateCustomerException("CustomerId in query string is different from the one specified in the Dto!");

            var existingCustomer = _customerRepository.GetCustomer(customerId);

            if (existingCustomer == null)
                throw new UpdateCustomerException($"Customer with Id {customerId} has not been found, update failed!");
        }

        private static void ValidateCustomer<TException>(CustomerDto customer) where TException : Exception
        {
            if (customer == null)
                ThrowException<TException>($"Customer is null, create failed!");

            if (string.IsNullOrWhiteSpace(customer?.FirstName))
                ThrowException<TException>($"Customer FirstName is null or empty, create failed!");

            if (string.IsNullOrWhiteSpace(customer?.LastName))
                ThrowException<TException>($"Customer LastName is null or empty, create failed!");

            if (customer?.Address == null)
                ThrowException<TException>($"Customer address is null, create failed!");

            if (string.IsNullOrWhiteSpace(customer?.Address?.InlineAddress))
                ThrowException<TException>($"Customer InlineAddress is null or empty, create failed!");

            if (customer?.UniqueFields == null)
                ThrowException<TException>($"Customer unique fields is null, create failed!");

            if (string.IsNullOrWhiteSpace(customer?.UniqueFields?.FavoriteFootballTeam) &&
                string.IsNullOrWhiteSpace(customer?.UniqueFields?.PersonalNumber))
            {
                ThrowException<TException>("Customer's PersonalNumber and FavoriteFootballTeam are null");
            }
        }

        private static void ThrowException<TException>(string message) where TException : Exception
        {
            throw (TException) Activator.CreateInstance(typeof(TException), message);
        }
    }  
}
