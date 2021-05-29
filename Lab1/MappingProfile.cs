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
            CreateMap<Movie, MovieViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Movie, MovieWithCommentsViewModel>();

        }
    }
}
