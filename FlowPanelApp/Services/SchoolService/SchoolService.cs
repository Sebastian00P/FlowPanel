using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.SchoolService
{
    public class SchoolService : ISchoolService
    {
        private readonly FlowContext _flowContext;

        public SchoolService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }

        public async Task<List<School>> GetAll()
        {
            return await _flowContext.Schools.ToListAsync();
        }
        public async Task CreateSchool(School school)
        {
            await _flowContext.Schools.AddAsync(school);
            await _flowContext.SaveChangesAsync();
        }
        public School GetSchoolById(long schoolID)
        {
            var school = _flowContext.Schools.Where(s => s.SchoolId == schoolID).FirstOrDefault();

            return school;
        }
        public async Task UpdateSchool(School school)
        {
            _flowContext.Schools.Update(school);
            await _flowContext.SaveChangesAsync();
        }
        public async Task<string> GetSchoolNameBySchoolId(long schoolId)
        {
            return await _flowContext.Schools.Where(x => x.SchoolId == schoolId).Select(x => x.SchoolName).FirstOrDefaultAsync();
        }

        public async Task<byte[]> GetSchoolLogoBySchoolId(long schoolId)
        {
            return await _flowContext.Schools.Where(x => x.SchoolId == schoolId).Select(x => x.Logo).FirstOrDefaultAsync();
        }

    }
}
