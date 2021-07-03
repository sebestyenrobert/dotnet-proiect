using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1.ViewModels
{
    public class UserWithDaysOffOfficialViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<UserDaysOffOfficialViewModel> UserDaysOffOfficial { get; set; }
    }
}
