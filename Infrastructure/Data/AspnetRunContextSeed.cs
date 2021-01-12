using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext aspnetRunContext, ILoggerFactory loggerFactory,
            int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!aspnetRunContext.Categories.Any())
                {
                    aspnetRunContext.Categories.AddRange(GetProconfiguredCategories());
                    await aspnetRunContext.SaveChangesAsync();
                }

                if (!aspnetRunContext.Products.Any())
                {
                    aspnetRunContext.Products.AddRange(GetPreconfiguredProducts());
                    await aspnetRunContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability = retryForAvailability + 1;
                    var log = loggerFactory.CreateLogger<AspnetRunContextSeed>();
                    log.LogError(e.Message);
                    await SeedAsync(aspnetRunContext, loggerFactory, retryForAvailability);
                }

                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private static IEnumerable<Category> GetProconfiguredCategories()
        {
            return new List<Category>
            {
                new Category() { CategoryName = "Telefon"},
                new Category() { CategoryName = "TV"},
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product() { ProductName = "IPhone" , CategoryId =1, UnitPrice = 19.5M, UnitsInStock = 10,
                QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false},

                new Product() { ProductName = "Samsung" , CategoryId =1, UnitPrice = 33.5M, UnitsInStock = 20,
                QuantityPerUnit = "4", UnitsOnOrder = 2, ReorderLevel = 3, Discontinued = true},

                 new Product() { ProductName = "LG TV" , CategoryId =2, UnitPrice = 123.45M, UnitsInStock = 200,
                QuantityPerUnit = "5", UnitsOnOrder = 3, ReorderLevel = 4, Discontinued = false},

            };
        }
    } // end of class
} // end of namespace
