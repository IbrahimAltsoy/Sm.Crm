using AutoMapper;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.DTOs.Employies;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Infrastructure.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReadCustomerDto, Customer>().ReverseMap();
            CreateMap<UserReadDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();


            CreateMap<ReadEmployiesDto,Employee>().ReverseMap();
                   
        }
    }
}
