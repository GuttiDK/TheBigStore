﻿using System.ComponentModel.DataAnnotations;

namespace TheBigStore.Repository.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        // CategoryName
        public string CategoryName { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = [];
    }
}