using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly FlowContext _flowContext;
        public CourseService(FlowContext flowContext) 
        {
            _flowContext = flowContext;
        }

        public async Task<List<Course>> GetCoursesByStudentId(long studentId)
        {
            return await _flowContext.Courses.Where(x => x.StudentId == studentId).ToListAsync();
        }

        public async Task CreateCourse(Course course)
        {
            _flowContext.Courses.Add(course);
            await _flowContext.SaveChangesAsync();
        }

        public async Task<Course> GetCourseById(long courseId)
        {
            return await _flowContext.Courses.Where(x =>x.CourseId == courseId).FirstOrDefaultAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            _flowContext.Courses.Update(course);
            await _flowContext.SaveChangesAsync();
        }
    }
}
