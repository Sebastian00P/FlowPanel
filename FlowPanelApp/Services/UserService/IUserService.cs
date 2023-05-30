using FlowPanelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.UserService
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<User> GetUserByUserNameAndPassword(string userName, string password);
        Task<List<User>> GetAll();
        Task DeleteUser(User user);
        Task EditUser(User user);
        Task<User> GetUserById(long userId);
    }
}
