using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly FlowContext _flowContext;
        public StudentService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }

        public async Task<List<Student>> GetStudentsByClassId(long ClassId)
        {
            return await _flowContext.Students.Where(x => x.ClassId == ClassId).ToListAsync();
        }

        public async Task CreateStudent(Student student)
        {
            _flowContext.Students.Add(student);
            await _flowContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(long studentId)
        {
            return await _flowContext.Students.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();         
        }

        public async Task EditStudent(Student student)
        {
            _flowContext.Students.Update(student);
            await _flowContext.SaveChangesAsync();
        }
    }
}
