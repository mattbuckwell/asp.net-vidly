using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly_project.Dtos;
using vidly_project.Models;

namespace vidly_project.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create a mapping configuration between 2 types, Generic method that takes 2 parameters - source and target
            // when we call this Create method, automapper using refleciton to scan these types, it finds their properties
            // and maps them based on their name - Convention Based mapping tool

            // Domain to Dto 
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}