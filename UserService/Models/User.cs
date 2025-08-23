namespace UserService.Models
{
    public class User
    {
        public Guid Id { get; set; }//unique identifier for the user
        public string Name { get; set; } //name of the user
        public string Email { get; set; } //email address of the user
    }
}
