﻿using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly FlowContext _flowContext;
        public ClassService(FlowContext flowContext) 
        { 
            _flowContext = flowContext;
        }

        public async Task<List<ClassModel>> GetClassesBySchoolId(long schoolId)
        {
            return await _flowContext.ClassModels.Where(x => x.SchoolId == schoolId).ToListAsync();
        }

        public async Task CreateClass(ClassModel Class)
        {
            _flowContext.ClassModels.Add(Class);
            await _flowContext.SaveChangesAsync();
        }
    }
}