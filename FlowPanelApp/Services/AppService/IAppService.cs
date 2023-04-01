using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.AppService
{
    public interface IAppService
    {
        string GetMd5Hash(string password);
    }
}
