using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNPLService.Models;
using BNPLService.Data;
using BNPLService.DTOs;
using BNPLService.Services;
using Microsoft.EntityFrameworkCore;

namespace BNPLService.Managers
{
    public class BNPLManager
    {
        private readonly BNPLDbContext _context;
        private readonly IProductClient _productClient;
        private readonly IUserClient _userClient;

        // Constructor: inject database and service clients
        public BNPLManager(BNPLDbContext context, IProductClient productClient, IUserClient userClient)
        {
            _context = context;
            _productClient = productClient;
            _userClient = userClient;
        }

        // Create a BNPL application after validating user and product
        public async Task<BNPLApp> CreateApplicationAsync(Guid userId, Guid productId)
        {
            // Step 1: Validate user via UserService
            var user = await _userClient.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            // Step 2: Validate product via ProductService
            var product = await _productClient.GetProductByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            if (!product.IsBNPLEligible)
                throw new Exception("Product is not eligible for BNPL");

            // Step 3: Create and save BNPL application
            var application = new BNPLApp
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending"
            };

            _context.BNPLApps.Add(application);
            await _context.SaveChangesAsync();

            return application;
        }

        // Get all BNPL applications
        public async Task<IEnumerable<BNPLApp>> GetAllApplicationsAsync()
        {
            return await _context.BNPLApps.ToListAsync();
        }

        // Get a specific application by ID
        public async Task<BNPLApp?> GetApplicationByIdAsync(Guid id)
        {
            return await _context.BNPLApps.FirstOrDefaultAsync(app => app.Id == id);
        }
    }
}
