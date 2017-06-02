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
            CreateMap<Movie, MovieDto>();

            // API to Domain
            CreateMap<CustomerDto, Customer>(); 
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}