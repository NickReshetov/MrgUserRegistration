using AutoMapper;
using MrgUserRegistration.DataAccess.EntityFramework.Entities;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.DataAccess.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
