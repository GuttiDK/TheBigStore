﻿using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    // Make a fully functional Customer domain class
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        // Add a first name, last name, email, and phone number
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }

        // Navigation properties
        public Address Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
