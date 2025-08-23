using Microsoft.AspNetCore.Mvc;
using ProductService.Services;
using ProductService.DTOs;

namespace ProductService.Controllers
{
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
	private readonly ProductManager _productManager;
    public ProductController(ProductManager productManager)
	{
		_productManager = productManager;
    }

	[HttpGet]
	public IActionResult GetAllProducts()
	{
		var products = _productManager.GetAll();
		return Ok(products);
    }
	[HttpPost]
	public IActionResult CreateProduct([FromBody] ProductCreateDto productCreateDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var product = _productManager.Create(productCreateDto.Name, productCreateDto.Price, productCreateDto.isBNPLEligible);
		return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
    }
}
}
