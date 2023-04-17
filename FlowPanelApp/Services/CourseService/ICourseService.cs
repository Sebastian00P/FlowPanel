using FlowPanelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.CourseService
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesByStudentId(long studentId);
        Task CreateCourse(Course course);
        Task<Course> GetCourseById(long courseId);
        Task UpdateCourse(Course course);
    }
}
