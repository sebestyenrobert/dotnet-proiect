using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Release { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Description { get; set; }
        public bool Watched { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
