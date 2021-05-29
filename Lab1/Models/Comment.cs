using System;
namespace Lab1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int Stars { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    
    }
}
