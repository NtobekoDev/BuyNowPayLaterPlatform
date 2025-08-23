using System;

namespace ProductService.Models;


public class Product
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public bool isBNPLEligible{ get; set; } // can this product be bought on BNPL?
}
