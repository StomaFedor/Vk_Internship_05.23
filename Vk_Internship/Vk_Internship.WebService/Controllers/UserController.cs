using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vk_Internship.Database.ModelsDto;
using Vk_Internship.Database.Repositories.UserRepository;

namespace Vk_Internship.WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetUser(string login)
        {
            IActionResult response;
            try
            {
                var userDto = await _userRepository.GetUserAsync(login);
                response = Ok(userDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IActionResult response;
            try
            {
                var userListDto = await _userRepository.GetUserListAsync();
                response = Ok(userListDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            IActionResult response;
            try
            {
                await _userRepository.CreateUserAsync(userDto);
                response = StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpDelete("{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            IActionResult response;

            try
            {
                await _userRepository.DeleteUserAsync(login);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
