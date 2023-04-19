using FlowPanelApp.Models;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByClassId(long ClassId);
        Task CreateTeacher(Teacher teacher);
        Task EditTeacher(Teacher teacher);
        Task<byte[]> GetTeacherPictureById(long teacherId);
    }
}
