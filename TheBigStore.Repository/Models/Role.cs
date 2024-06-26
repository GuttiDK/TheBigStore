﻿using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; }
        public List<User>? Users { get; set; }
    }
}
