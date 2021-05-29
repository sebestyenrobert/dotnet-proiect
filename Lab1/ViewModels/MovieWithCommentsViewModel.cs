using System;
using System.Collections.Generic;

namespace Lab1.ViewModels
{
    public class MovieWithCommentsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Release { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string Description { get; set; }
        public bool Watched { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
