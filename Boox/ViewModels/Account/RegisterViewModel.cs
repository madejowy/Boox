using Boox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Please enter up minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match! Try Again")]
        public string RepeatedPassword { get; set; }
        public AccountType AccountType { get; set; }
    }
}
