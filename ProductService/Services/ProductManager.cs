using ProductService.Models;
using System;

namespace ProductService.Services
{
public class ProductManager
{
	private readonly List<Product> _products = new();
	
public IEnumerable<Product> GetAll() => _products;

        public Product Create(string name, decimal price, bool isBNPLEligible)
	{
		var product = new Product
		{
			Id = Guid.NewGuid(),
			Name = name,
			Price = price,
			isBNPLEligible = isBNPLEligible

		};
		_products.Add(product);
		return product;
	}
}
}