using System;
using System.Collections.Generic;
using Lab1.Models;

namespace Lab1.ViewModels.Rentals
{
    public class RentalsForUserResponse
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<MovieViewModel> Movies { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
