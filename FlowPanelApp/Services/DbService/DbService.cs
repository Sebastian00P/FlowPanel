using FlowPanelApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.DbService
{
    public class DbService : IDbService
    {
        private readonly FlowContext _flowContext;

        public DbService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }
    }
}
