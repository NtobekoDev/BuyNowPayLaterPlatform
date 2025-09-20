using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }//unique identifier for the user
        [Required]
        public string Name { get; set; } //name of the user
        [Required]
        public string Email { get; set; } //email address of the user
    }
}
