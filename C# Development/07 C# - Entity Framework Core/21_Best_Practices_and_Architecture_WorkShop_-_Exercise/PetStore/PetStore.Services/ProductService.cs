using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumeration;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public ProductDetailsServiceModel GetById(string id)
        {
            Product product = this.dbContext.Products.FirstOrDefault(p=>p.Id == id);
            if (product==null)
            {
                throw new ArgumentException("Product not found!");
            }

            ProductDetailsServiceModel serviceModel = this.mapper.Map<ProductDetailsServiceModel>(product);

            return serviceModel;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = mapper.Map<Product>(model);
                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid product type!");
            }


        }

        public ICollection<ListAllProductByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType productType;
            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid product type provided!");
            }

            var productsServiceModels = this.dbContext
                .Products
                .Where(p => p.ProductType == productType)
                .ProjectTo<ListAllProductByProductTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            //TODO: FIX
            var products = this.dbContext
                .Products
                .Select(x=>new ListAllProductsServiceModel()
                {
                    Name = x.Name,
                    ProductId = x.Id,
                    Price = x.Price,
                    ProductType = x.ProductType.ToString()
                })
                .ToList();
            
            return products;
        }

        public bool RemoveById(string id)
        {
            Product productToRemove = this.dbContext
                .Products
                .Find(id);
            if (productToRemove == null)
            {
                throw new ArgumentException("Product with given id doesn't exist!");
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;
            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            Product productToRemove = this.dbContext
                .Products
                .FirstOrDefault(x => x.Name == name);
            if (productToRemove == null)
            {
                throw new ArgumentException("Product with given name doesn't exist!");
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;
            return wasDeleted;
        }

        public ICollection<ListAllProductByNameServiceModel> SearchByName(string searchStr, bool caseSensitive)
        {
            ICollection<ListAllProductByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext
                    .Products
                    .Where(x => x.Name.Contains(searchStr))
                    .ProjectTo<ListAllProductByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext
                    .Products
                    .Where(x => x.Name.ToLower().Contains(searchStr.ToLower()))
                    .ProjectTo<ListAllProductByNameServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);
                Product productToUpdate = this.dbContext.Products.Find(id);
                if (productToUpdate == null)
                {
                    throw new ArgumentException();
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid product type!");
            }

        }
    }
}
