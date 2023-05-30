using FlowPanelApp.Context;
using FlowPanelApp.Models;
using FlowPanelApp.Services.AppService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly FlowContext _flowContext;
        private readonly IAppService _appService;

        public UserService(FlowContext flowContext, IAppService appService)
        {
            _flowContext = flowContext;
            _appService = appService;
        }

        public async Task AddUser(User user)
        {
            var passwordHash = _appService.GetMd5Hash(user.Password);
            user.Password = passwordHash;
            user.Role = "User";
            _flowContext.Users.Add(user);
            await _flowContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUserNameAndPassword(string userName, string password)
        {         
            var passwordHash = _appService.GetMd5Hash(password);          
            return await _flowContext.Users.Where(x => x.UserName == userName && x.Password == passwordHash && x.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _flowContext.Users.ToListAsync();
        }
        public async Task DeleteUser(User user)
        {
            _flowContext.Remove(user);
            await _flowContext.SaveChangesAsync();
        }
        public async Task EditUser(User user)
        {
            var passwordHash = _appService.GetMd5Hash(user.Password);
            user.Password = passwordHash;
            _flowContext.Update(user);
            await _flowContext.SaveChangesAsync();
        }
        
        public async Task<User> GetUserById(long userId)
        {
            return await _flowContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

    }
}
