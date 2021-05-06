using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingCore.Models;
using TestingCore.DTO;

namespace TestingCore.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MembershipType, MembershipTypeDTO>();
            CreateMap<Genre, GenreDTO>();

            //DTO to Domain
            CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<MovieDTO, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());


            CreateMap<MembershipTypeDTO, MembershipType>()
                .ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}
