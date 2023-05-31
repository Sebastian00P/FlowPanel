using FlowPanelApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.GradeService
{
    public interface IGradeService
    {
        Task<List<Grade>> GetGradesByCourseId(long courseId);
        Task CreateNewGrade(Grade grade);
        Task<Grade> GetGradeById(long gradeId);
        Task EditGrade(Grade grade);
        Task RemoveGrade(Grade grade);
    }
}
