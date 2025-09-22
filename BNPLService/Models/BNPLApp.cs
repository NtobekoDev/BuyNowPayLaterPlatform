using System;
namespace BNPLService.Models
{
	public class BNPLApp
    {
		public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Status { get; set; } // e.g., "Pending", "Approved", "Rejected"
    }
}