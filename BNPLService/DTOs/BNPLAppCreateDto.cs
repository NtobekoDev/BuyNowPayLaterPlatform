using System.ComponentModel.DataAnnotations;

public class BNPLAppCreateDto
{
	[Required]
	public Guid UserId { get; set; }
	[Required]
	public Guid ProductId { get; set; }

}
