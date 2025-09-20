using UserService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models; 
using Swashbuckle.AspNetCore.SwaggerGen;
using UserService.Data;

namespace UserService.Services
{
    public class UserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList(); // Returns all users
        }

        public User Create(string name, string email)
        {
        var user = new User
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier for the user
                Name = name,
                Email = email
            };
            _context.Users.Add(user); 
            _context.SaveChanges();
            return user; // Return the created user
        }
    }
}
