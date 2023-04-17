using FlowPanelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.ClassService
{
    public interface IClassService
    {
        Task<List<ClassModel>> GetClassesBySchoolId(long schoolId);
        Task CreateClass(ClassModel Class);
        Task EditClass(ClassModel Class);
        Task<ClassModel> GetClassById(long classId);
    }
}
