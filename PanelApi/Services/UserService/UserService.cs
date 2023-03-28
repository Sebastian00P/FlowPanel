using FlowPanelApp.Models;
using PanelApi.Services.DbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelApi.Services.UserService
{
    public class UserService : IUserService, IDbService
    {
        private readonly IDbService _dbService;

        public UserService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task AddUser(User user)
        {

        }

        public bool CheckUserAuth(string username, string password)
        {
            return true;
        }
    }
}
