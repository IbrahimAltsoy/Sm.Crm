using AutoMapper;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Infrastructure.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReadCustomerDto, Customer>().ReverseMap();            
        }
    }
}
