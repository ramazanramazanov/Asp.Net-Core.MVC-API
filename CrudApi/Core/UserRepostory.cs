using CrudApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Core
{
    public class UserRepostory:IUserRepostory
    {
        private readonly AppDbContext _context;
        public UserRepostory(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void UpdateUser(int id, User user)
        {
            var myUser = _context.Users.Find(id);
            myUser.Name = user.Name;
            myUser.Surname = user.Surname;
            myUser.Email = user.Email;
            _context.SaveChanges();

        }
    }
}
