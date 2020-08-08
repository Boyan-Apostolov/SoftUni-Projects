using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.Data;
using CarDealer.DataTransferObjects;
using CarDealer.Models;
using CarDealer.XmlHelper;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ImportSuppliers(context, File.ReadAllText("../../../Datasets/suppliers.xml"));
            ImportParts(context, File.ReadAllText("../../../Datasets/parts.xml"));
            ImportCars(context, File.ReadAllText("../../../Datasets/cars.xml"));
            ImportCustomers(context, File.ReadAllText("../../../Datasets/customers.xml"));
            ImportSales(context, File.ReadAllText("../../../Datasets/sales.xml"));

            var result = GetTotalSalesByCustomer(context);
            File.WriteAllText("../../../customers-total-sales.xml", result);
        }
        //Problem 09 
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersDtops = XMLConverter.Deserializer<ImportSupplierDto>(inputXml, "Suppliers");

            var results = suppliersDtops.Select(s => new Supplier()
            {
                Name = s.Name,
                IsImporter = s.IsImporter
            })
                .ToArray();

            context.Suppliers.AddRange(results);
            context.SaveChanges();

            return $"Successfully imported {results.Length}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDtos = XMLConverter.Deserializer<ImportPartsDto>(inputXml, "Parts");

            var parts = partsDtos
                .Where(i => context.Suppliers.Any(s => s.Id == i.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDtos = XMLConverter.Deserializer<ImportCarDto>(inputXml, "Cars");

            //var cars = carsDtos
            //    .Select(x => new Car
            //    {
            //        Parts = x.Parts.Select(x => x.Id).Distinct()
            //    })

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDtos)
            {
                var uniqueParts = carDto.Parts.Select(s => s.Id).Distinct().ToArray();

                var realParts = uniqueParts.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(p => new PartCar()
                    {
                        PartId = p
                    }).ToArray()

                };

                cars.Add(car);

            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var cursomerDtos = XMLConverter.Deserializer<ImportCustomerDto>(inputXml, "Customers");

            var customers = cursomerDtos.Select(x => new Customer()
            {
                Name = x.Name,
                IsYoungDriver = x.isYoungDriver,
                BirthDate = DateTime.Parse(x.birthDate)
            })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDtos = XMLConverter.Deserializer<ImportSaleDto>(inputXml, "Sales");

            var sales = salesDtos
                .Where(i => context.Cars.Any(a => a.Id == i.carId))
                .Select(c => new Sale()
                {
                    CarId = c.carId,
                    Discount = c.discount,
                    CustomerId = c.customerId
                })
                .ToArray();

            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsfromDb = context
                .Cars
                .Where(c => c.TravelledDistance >= 2000000)
                .Select(c => new ExportCarsWithDistanceDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c=>c.Make)
                .ThenBy(c=>c.Model)
                .Take(10)
                .ToArray();

            var resultCars = XMLConverter.Serialize(carsfromDb, "cars");

            return resultCars;

        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarsFromBMWDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var resultXml = XMLConverter.Serialize(cars, "cars");
            return resultXml;
        }

        //Problem 16 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportNonImporterSuppliers()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var result = XMLConverter.Serialize(suppliers, "suppliers");
            return result;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarsWithTheirPartsDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new PartWithItsNameAndPriceDTO()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var result = XMLConverter.Serialize(cars, "cars");
            return result;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .ToArray()
                .Where(c => c.Sales.Any(s => s.CarId != null))
                .Select(x => new ExportTotalSalesByCustomerDto()
                {
                    FullName = x.Name,
                    BoughtCarsCount = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var result = XMLConverter.Serialize(customers, "customers");
            return result;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Include(x => x.Car)
                .ThenInclude(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .Include(x => x.Customer)
                .Select(s => new ExportSalesDiscount()
                {
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    Discount = s.Discount.ToString("F2"),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -( s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100))).ToString("F2"),
                    CarDto = new ExportCarAtributeDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    }
                }).ToArray();

            var xmlResult = XMLConverter.Serialize(salesWithDiscount, "sales");
            return xmlResult;

        }
    }
}