using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk_Internship.Database.Models;
using Vk_Internship.Database.ModelsDto;

namespace Vk_Internship.Database.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserDto userDto);

        Task DeleteUserAsync(string login);

        Task<UserDto> GetUserAsync(string login);

        Task<IEnumerable<UserDto>> GetUserListAsync();
    }
}
