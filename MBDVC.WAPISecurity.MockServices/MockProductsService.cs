using MBDVC.WAPISecurity.IServices;
using System;
using MBDVC.WAPISecurity.Models;
using System.Collections.Generic;
using System.Linq;

namespace MBDVC.WAPISecurity.MockServices
{
    public class MockProductsService : IProductsService
    {
        private IList<Product> products;

        public MockProductsService()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Produkt 1"},
                new Product { Id = 2, Name = "Produkt 2"},
                new Product { Id = 3, Name = "Produkt 3"},
                new Product { Id = 3, Name = "Produkt 4", IsDeleted = true },
                new Product { Id = 3, Name = "Produkt 5", IsDeleted = true },
            };
        }

        public IList<Product> Get() => products;

        public Product Get(int id) => products.SingleOrDefault(p => p.Id == id);
    }
}
