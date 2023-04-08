using FlowPanelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsByClassId(long ClassId);
    }
}
