using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly FlowContext _flowContext;
        public TeacherService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }

        public async Task<Teacher> GetTeacherByClassId(long ClassId)
        {
            return await _flowContext.Teachers.Where(x => x.ClassId == ClassId).FirstOrDefaultAsync();
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            _flowContext.Teachers.Add(teacher);
            await _flowContext.SaveChangesAsync();
        }
    }
}
