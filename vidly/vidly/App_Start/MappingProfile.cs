using AutoMapper;
using vidly.Dtos;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.ID, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.ID, opt => opt.Ignore());
        }
    }
}