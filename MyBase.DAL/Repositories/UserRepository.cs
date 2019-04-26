using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyBase.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
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
            _context.Entry(user).State = EntityState.Modified;

            if (user.ImageUrl == null)
            {
                _context.Entry(user).Property(e => e.ImageUrl).IsModified = false;
            }
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetAllNotDeletedUsersAsync(int listSize, int startFrom)
        {
            return _context.Users
                .Where(u => !u.IsDeleted)
                .OrderBy(u => u.Id)
                .Skip(startFrom)
                .Take(listSize)
                .ToListAsync();
        }

        public Task<int> NotDeletedUsersCountAsync()
        {
            return _context.Users.CountAsync(x => !x.IsDeleted);
        }
    }
}

