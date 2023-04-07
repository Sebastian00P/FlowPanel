using FlowPanelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.ClassService
{
    public interface IClassService
    {
        Task<List<ClassModel>> GetClassesBySchoolId(long schoolId);
    }
}
