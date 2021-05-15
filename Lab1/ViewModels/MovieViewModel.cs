using System;
namespace Lab1.ViewModels
{
    public class MovieViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Director { get; set; }

        public string Release { get; set; }

        [Range(0, 10)]
        public double rating { get; set; }
    }
}
