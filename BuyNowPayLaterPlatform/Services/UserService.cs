using UserService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models; // Add this using directive at the top of the file
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UserService.Services
{
    public class UserService
    {
        private readonly List<User> users = new(); // In-memory list to store users
        public IEnumerable<User> GetAllUsers()
        {
            return users; // Returns all users
        }

        public User Create(string name, string email)
        {
                       var user = new User
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier for the user
                Name = name,
                Email = email
            };
            users.Add(user); // Add the new user to the in-memory list
            return user; // Return the created user
        }
    }
}
