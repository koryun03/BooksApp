﻿using Microsoft.AspNetCore.Identity;

namespace BooksApp.Domain.Entities.Users
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
    }

}
