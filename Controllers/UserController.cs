using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toDoApp.Dtos;
using toDoApp.Models;
using toDoApp.Repositories;

namespace toDoApp.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto newUser)
        {
            var response = await _repository.RegisterAsync(new User { Username = newUser.Username }, newUser.Password);
            if (response == -1)
            {
                return BadRequest("User already exists");
            }

            return Ok();
        }
    }
}