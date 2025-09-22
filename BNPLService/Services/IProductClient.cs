using System;
using System.Threading.Tasks;
using BNPLService.DTOs;

namespace BNPLService.Services
{

	public interface IProductClient
	{
		Task<ProductDTO?> GetProductByIdAsync(Guid productId);
    }
	
}