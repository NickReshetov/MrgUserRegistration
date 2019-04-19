using AutoMapper;
using MrgUserRegistration.DataAccess.EntityFramework.Entities;
using MrgUserRegistration.Dtos;

namespace MrgUserRegistration.DataAccess.Mappings
{
    public class UniqueFieldsProfile : Profile
    {
        public UniqueFieldsProfile()
        {
            CreateMap<UniqueFields, UniqueFieldsDto>().ReverseMap();
        }
    }
}
