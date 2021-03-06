using System;
using AutoMapper;
using Lab1.Models;
using Lab1.ViewModels;
using Lab1.ViewModels.Rentals;

namespace Lab1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Movie, MovieWithCommentsViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();

            CreateMap<Rental, RentalsForUserResponse>().ReverseMap();
        }
    }
}
