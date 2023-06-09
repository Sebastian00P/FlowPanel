using FlowPanelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.AppService
{
    public class AppService : IAppService
    {
        private static User _user;
        public string GetMd5Hash(string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public void HoldUserData(User user)
        {
            _user = user;
        }
        public User GetCurrentSessionUserData()
        {
            return _user;
        }
            
    }

}
