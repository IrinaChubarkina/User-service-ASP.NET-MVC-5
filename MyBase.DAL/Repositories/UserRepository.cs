using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            user.IsDeleted = true;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //логика в репо - не норм
            if (user.Image == null)
            {
                _context.Entry(user).Property(e => e.Image).IsModified = false;
            }
        }

        public Task<User> GetUserAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetListOfUsersAsync(int listSize, int startFrom)
        {
            return _context.Users
                .Where(u => u.IsDeleted == false)
                .OrderBy(u => u.Id)
                .Skip(startFrom)
                .Take(listSize)
                .ToListAsync();
        }

        public Task<int> GetCountOfUsersAsync()
        {
            return _context.Users.CountAsync(x => x.IsDeleted == false);
        }
    }
}

