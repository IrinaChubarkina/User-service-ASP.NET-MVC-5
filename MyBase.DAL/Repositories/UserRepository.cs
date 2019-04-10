using MyBase.DAL.EF;
using MyBase.DAL.Entities;
using MyBase.DAL.Interfaces;
using MyBase.DAL.Specifications.Interfaces;
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
        }

        public Task<User> GetUserAsync(int id)
        {
            return _context.Users
                .Include(x => x.Contact)
                .Include(x => x.Picture)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //паттерн спецификация нужен
        public Task<List<User>> GetListAsync(int listSize, int startFrom)
        {
            return _context.Users
                .Where(u => u.IsDeleted == false)
                .Include(u => u.Contact)
                .Include(u => u.Picture)
                .OrderBy(u => u.Id)
                .Skip(startFrom)
                .Take(listSize)
                .ToListAsync();
        }
        
        public Task<int> GetUsersCountAsync()
        {            
            return _context.Users.CountAsync();
        }
    }
}

