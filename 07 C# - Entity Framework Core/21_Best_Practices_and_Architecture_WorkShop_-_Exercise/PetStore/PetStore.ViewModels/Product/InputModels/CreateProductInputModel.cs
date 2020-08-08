using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.ViewModels.Product.InputModels
{
    public class CreateProductInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int ProductType { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
