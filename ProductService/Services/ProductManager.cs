using ProductService.Models;
using ProductService.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProductService.Services
{
    public class ProductManager
    {
        private readonly ProductDbContext _context;
        public ProductManager(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products;

        public Product Create(string name, decimal price, bool isBNPLEligible)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                isBNPLEligible = isBNPLEligible
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            return product; // Return the created product, not the DbSet
        }

        public Product GetProductById(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}