using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; } // Name of the user
       
        [Required]
        [EmailAddress]
        public string Email { get; set; } // Email address of the user
    }
}
