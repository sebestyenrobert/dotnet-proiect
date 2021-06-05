using System;
namespace Lab1.ViewModels.Authentication
{
    public class ConfirmUserRequest
    {
        public String Email { get; set; }
        public String ConfirmationToken { get; set; }
    }
}
