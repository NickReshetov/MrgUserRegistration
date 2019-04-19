using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrgUserRegistration.DataAccess.EntityFramework;
using MrgUserRegistration.DataAccess.EntityFramework.Entities;
using MrgUserRegistration.DataAccess.Repositories.Interfaces;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MrgUserRegistrationDbContext _context = new MrgUserRegistrationDbContextFactory().CreateDbContext();
        private readonly IMapper _mapper;

        public CustomerRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customerEntities = _context.Customers
                .Include(c => c.Address)
                .Include(c => c.UniqueFields);

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customerEntities);

            return customersDto;
        }

        public CustomerDto GetCustomer(Guid customerId)
        {
            var customerEntity = GetCustomerById(customerId);

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return customerDto;
        }

        private Customer GetCustomerById(Guid customerId)
        {
            var customerEntity = _context.Customers
                .Include(c=>c.Address)
                .Include(c => c.UniqueFields)
                .SingleOrDefault(c => c.Id == customerId);

            return customerEntity;
        }

        public CustomerDto GetCustomer(string firstName, string lastName, AddressDto address)
        {
            var customerEntity = _context.Customers
                .Include(c => c.Address)
                .Include(c => c.UniqueFields)
                .SingleOrDefault(c => c.FirstName == firstName && 
                                      c.LastName == lastName && 
                                      c.Address.InlineAddress == address.InlineAddress);

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return customerDto;
        }

        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);

            _context.Customers.Add(customerEntity);

            _context.SaveChanges();

            var createdCustomerDto = _mapper.Map<CustomerDto>(customerEntity);

            return createdCustomerDto;
        }

        public CustomerDto UpdateCustomer(CustomerDto customer)
        {
            var existingCustomer = GetCustomerById(customer.Id);

            var customerEntity = _mapper.Map(customer, existingCustomer);

            _context.Customers.Update(customerEntity);

            _context.SaveChanges();

            var updatedCustomerDto = _mapper.Map<CustomerDto>(customerEntity);

            return updatedCustomerDto;
        }
    }
}
