using FlowPanelApp.Models;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByClassId(long ClassId);
    }
}
