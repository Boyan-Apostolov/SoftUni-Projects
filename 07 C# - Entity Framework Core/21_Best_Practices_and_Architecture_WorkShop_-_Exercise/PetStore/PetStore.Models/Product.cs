﻿using System;
using System.ComponentModel.DataAnnotations;
using PetStore.Models.Enumeration;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ProductType  ProductType { get; set; }
        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
