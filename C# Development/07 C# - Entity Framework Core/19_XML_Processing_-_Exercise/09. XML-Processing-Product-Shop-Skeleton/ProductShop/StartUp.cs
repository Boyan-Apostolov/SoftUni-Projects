using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportUsers(context, usersXml);
            ImportProducts(context, productsXml);
            ImportCategories(context, categoriesXml);
            ImportCategoryProducts(context, categoriesProductsXml);

            //string productsInRange = GetProductsInRange(context);
            //
            //File.WriteAllText("../../../results/productsInRange.xml", productsInRange);
            //
            //string soldProducts = GetSoldProducts(context);
            //
            //File.WriteAllText("../../../results/soldProducts.xml", soldProducts);
            //
            //string categoriesByProductsCount = GetCategoriesByProductsCount(context);
            //
            //File.WriteAllText("../../../results/categories-by-products.xml.xml", categoriesByProductsCount);

            string productsInRange = GetProductsInRange(context);

            File.WriteAllText("../../../results/products-in-range.xml", productsInRange);

        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var usersResult = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            //List<User> users = new List<User>();
            //
            //foreach (var importUserDto in usersResult)
            //{
            //    var user = new User()
            //    {
            //        FirstName = importUserDto.FirstName,
            //        LastName = importUserDto.LastName,
            //        Age = importUserDto.Age
            //    };
            //    users.Add(user);
            //}

            var users = usersResult
                .Select(
                    u => new User
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age
                    })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
            return null;
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productDtos = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = productDtos
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerId = p.BuyerId,
                    SellerId = p.SellerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoeiesDtop = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            List<Category> categories = new List<Category>();

            foreach (var dtop in categoeiesDtop)
            {
                if (dtop.Name == null)
                {
                    continue;
                }

                var category = new Category { Name = dtop.Name };
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categoryProductDtos = XMLConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categories = categoryProductDtos
                .Where(i =>
                    context.Categories.Any(s => s.Id == i.CategoryId) &&
                    context.Products.Any(s => s.Id == i.ProductId))
                .Select(c => new CategoryProduct
                {
                    CategoryId = c.CategoryId,
                    ProductId = c.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Problem 05 - FIX
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(x => new ExportProductInfoDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .OrderBy(p => p.Price)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);

            return result;
        }

        //Problem 06 - FIX
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(x => new ExportUserSoldProductDtop
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(p => new UserProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                .ToArray();

            var result = XMLConverter.Serialize(usersWithProducts, "Users");
            return result;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Select(x => x.Product).Sum(p => p.Price),
                    AveragePrice = c.CategoryProducts.Select(x => x.Product).Average(p => p.Price),
                })
                .OrderByDescending(c => c.Count).ThenBy(c => c.TotalRevenue)
                .ToArray();

            var result = XMLConverter.Serialize(categories, "Categories");
            return result;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndProducts = context
                .Users
                .ToArray()
                .Where(p => p.ProductsSold.Any())
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new ExportProductCountDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProduct.Count)
                .Take(10)
                .ToArray();

            var result = new ExportUserCountDto()
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = usersAndProducts
            };

            var resut = XMLConverter.Serialize(result, "Users");
            return resut;
        }
    }
}