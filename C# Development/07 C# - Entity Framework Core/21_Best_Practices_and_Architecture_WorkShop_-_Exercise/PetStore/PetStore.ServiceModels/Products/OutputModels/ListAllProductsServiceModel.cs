using System;
using System.Collections.Generic;
using System.Text;
using PetStore.Models.Enumeration;

namespace PetStore.ServiceModels.Products.OutputModels
{
    public class ListAllProductsServiceModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}
