using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infra.Data.Repository
{
    public class ProductRepositoryInMemory : IProductRepository
    {
        private ICollection<Product> _products;

        public ProductRepositoryInMemory()
        {
            _products = new List<Product>();
            _products.Add(new Product { Id = "0001", Name = "Produto 1", Price = 10 });
            _products.Add(new Product { Id = "0002", Name = "Produto 2", Price = 8 });
            _products.Add(new Product { Id = "0003", Name = "Produto 3", Price = 6 });
        }

        public Product GetProduct(string productId)
        {
            return _products.FirstOrDefault(product => product.Id == productId);
        }
    }
}
