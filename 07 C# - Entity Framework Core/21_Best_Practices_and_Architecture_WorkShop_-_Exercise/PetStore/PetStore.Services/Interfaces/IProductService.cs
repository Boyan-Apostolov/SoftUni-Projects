using System;
using System.Collections.Generic;
using System.Text;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        ProductDetailsServiceModel GetById(string id);
        void AddProduct(AddProductInputServiceModel model);

        ICollection<ListAllProductByProductTypeServiceModel> ListAllByProductType(string type);

        ICollection<ListAllProductsServiceModel> GetAll();

        bool RemoveById(string id);
        bool RemoveByName(string name);

        ICollection<ListAllProductByNameServiceModel> SearchByName(string searchStr, bool caseSensitive);

        void EditProduct(string id, EditProductInputServiceModel model);
    }
}
