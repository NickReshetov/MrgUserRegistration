using AutoMapper;
using MrgUserRegistration.DataAccess.EntityFramework.Entities;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.DataAccess.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
