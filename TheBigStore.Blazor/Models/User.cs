﻿using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Blazor.Models
{
    public class User
    {
        public int Id { get; set; }

        // User
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? CustomerId { get; set; }

        // Navigation properties
        public Role? Role { get; set; }
        public Customer? Customer { get; set; }
    }
}
