using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk_Internship.Database.Models;
using Vk_Internship.Database.ModelsDto;

namespace Vk_Internship.Database.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(VkDbContext context) : base(context) { }

        private User ConvertDtoToUser(UserDto dto)
        {
            if (dto.Code_state != CodeState.Active && dto.Code_state != CodeState.Active)
                throw new Exception("The user status is incorrectly specified");
            if (dto.Code_group != CodeGroup.Admin && dto.Code_group != CodeGroup.User)
                throw new Exception("The user's group is specified incorrectly");
            var user = new User()
            {
                Login = dto.Login,
                Password = dto.Password,
                Group = new User_group() { Code = dto.Code_group, Description = dto.GroupDescription },
                State = new User_state() { Code = dto.Code_state, Description = dto.StateDescription },
            };
            return user;
        }

        private UserDto ConvertUserToDto(User user)
        {
            var userDto = new UserDto()
            {
                Login = user.Login,
                Password = user.Password,
                Created_Date = user.Created_Date,
                Code_group = user.Group.Code,
                Code_state = user.State.Code,
                GroupDescription = user.Group.Description,
                StateDescription = user.State.Description
            };
            return userDto;
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = ConvertDtoToUser(userDto);
            if (_context.Users.Where(item => item.Login == user.Login).Any()) {
                user = _context.Users.Include(item => item.State).FirstOrDefault(item => item.Login == user.Login);
                if (user.State.Code == CodeState.Active)
                    throw new Exception("such user is already exists");
                user.State.Code = CodeState.Active;
                _context.Entry(user).State = EntityState.Modified;
            } else 
                await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string login)
        {
            if (!_context.Users.Where(item => item.Login == login).Any())
                throw new Exception("such user does not exist");
            var user = _context.Users.Include(item => item.State).FirstOrDefault(item => item.Login == login);
            user.State.Code = CodeState.Blocked;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserAsync(string login)
        {
            if (!_context.Users.Where(item => item.Login == login).Any())
                throw new Exception("such user does not exist");
            var user = _context.Users.Include(item => item.Group).Include(item => item.State).FirstOrDefault(item => item.Login == login);
            var userDto = ConvertUserToDto(user);
            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetUserListAsync()
        {
            var list = await _context.Users.Include(item => item.Group).Include(item => item.State).ToListAsync();
            var result = new List<UserDto>();
            foreach (var item in list)
                result.Add(ConvertUserToDto(item));
            return result;
        }
    }
}
