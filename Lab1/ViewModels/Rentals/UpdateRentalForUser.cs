using System;
using System.Collections.Generic;

namespace Lab1.ViewModels.Rentals
{
    public class UpdateRentalForUser
    {
        public int Id { get; set; }
        public List<int> MovieIds { get; set; }
    }
}
