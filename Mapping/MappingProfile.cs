using AutoMapper;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            // Domain to API
            CreateMap<Customer,CustomerDto>(); 

            // API to Domain
            CreateMap<Customer,CustomerDto>(); 

        }
    }
}