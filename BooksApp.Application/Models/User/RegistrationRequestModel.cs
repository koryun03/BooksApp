﻿namespace BooksApp.Application.Models.User
{
    public class RegistrationRequestModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
