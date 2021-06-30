﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.Models
{
    public enum AccountType
    {
        Administrator,
        StandardUser
    }
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
