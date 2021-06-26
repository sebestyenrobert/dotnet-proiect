using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Data;
using Lab1.Models;

namespace Lab1.Services
{
    public class MoviesService
    {
        public ApplicationDbContext _context;
        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAllAboveRating(double minRating)
        {
            return _context.Movies.Where(m => m.Rating >= minRating).ToList();
        }
    }
}
