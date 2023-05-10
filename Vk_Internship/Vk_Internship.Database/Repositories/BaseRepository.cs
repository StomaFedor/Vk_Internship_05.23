using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_Internship.Database.Repositories
{
    public class BaseRepository
    {
        protected readonly VkDbContext _context;

        public BaseRepository(VkDbContext context)
        {
            _context = context;
        }
    }
}
