using FlowPanelApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelApi.Services.DbService
{
    public class DbService
    {
        private readonly FlowContext _flowContext;

        public DbService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }
    }
}
