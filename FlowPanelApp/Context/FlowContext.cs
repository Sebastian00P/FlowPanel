using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Context
{
    public class FlowContext : DbContext
    {

        public FlowContext(DbContextOptions<FlowContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ClassModel> ClassModels { get; set; }
    }
}
