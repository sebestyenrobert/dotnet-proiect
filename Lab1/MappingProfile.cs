using System;
using AutoMapper;
using Lab1.Models;
using Lab1.ViewModels;

namespace Lab1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Holiday, HolidayViewModel>().ReverseMap();
            CreateMap<UserDaysOff, UserDaysOffViewModel>().ReverseMap();
            CreateMap<UserDaysOffOfficial, UserDaysOffOfficialViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UserWithDaysOffOfficialViewModel>().ReverseMap();
            //CreateMap<Movie, MovieWithCommentsViewModel>().ReverseMap();
        }
    }
}
