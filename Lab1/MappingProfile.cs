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
            CreateMap<UserDaysOff, UserDaysOffViewModel>().ReverseMap();
            CreateMap<UserDaysOffOfficial, UserDaysOffOfficialViewModel>().ReverseMap();
            //CreateMap<Movie, MovieWithCommentsViewModel>().ReverseMap();
        }
    }
}
