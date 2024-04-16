﻿namespace TheBigStore.Service.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        // User
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Role
        public int? RoleId { get; set; }
        public RoleDto? Role { get; set; }

        // Customer
        public int? CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
    }
}
