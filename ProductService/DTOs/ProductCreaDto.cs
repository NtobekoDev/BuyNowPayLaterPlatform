using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
public class ProductCreateDto
{
	[Required]
	public string Name { get; set; }
	[Required]
	[Range(1, double.MaxValue)]
	public decimal Price { get; set; }
	public bool isBNPLEligible { get; set; } 
}
}