using CrudApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Core
{
   public interface IUserRepostory
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task AddUserAsync(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
