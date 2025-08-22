using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly Services.UserService _userService; // Fully qualify to avoid ambiguity
        public UserController(Services.UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _userService.Create(dto.Name, dto.Email);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }
    }
}
