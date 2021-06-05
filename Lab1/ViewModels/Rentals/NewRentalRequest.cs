using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.ViewModels.Rentals
{
    public class NewRentalRequest
    {
        public List<int> RentalMovieIds { get; set; }
        public DateTime? RentalDateTime { get; set; }
    }
}
