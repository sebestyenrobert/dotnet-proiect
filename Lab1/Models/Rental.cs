using System;
using System.Collections.Generic;

namespace Lab1.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
