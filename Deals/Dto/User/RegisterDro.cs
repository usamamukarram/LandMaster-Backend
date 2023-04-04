﻿using System.ComponentModel.DataAnnotations;

namespace Deals.Dto.User
{
    public class RegisterDro
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Notes { get; set;  } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
