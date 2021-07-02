using System;
namespace Lab1.ViewModels
{
    public class UserDaysOffViewModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Decided_user_id { get; set; }
        public string Reason { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Accepted { get; set; }
        public int Refused { get; set; }
        public int Days { get; set; }
    }
}
