using FlowPanelApp.Context;
using FlowPanelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly FlowContext _flowContext;
        public GradeService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }

        public async Task<List<Grade>> GetGradesByCourseId(long courseId)
        {
            return await _flowContext.Grades.Where(x => x.CourseId == courseId && x.IsActive == true).ToListAsync();
        }

        public async Task CreateNewGrade(Grade grade)
        {
            var dateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            grade.AddDate = DateTime.ParseExact(dateTime, "dd-MM-yyyy HH:mm:ss", null);
            grade.IsActive = true;
            _flowContext.Grades.Add(grade);
            await _flowContext.SaveChangesAsync();
        }

        public async Task<Grade> GetGradeById(long gradeId)
        {
            return await _flowContext.Grades.Where(x => x.GradeId == gradeId).FirstOrDefaultAsync();
        }

        public async Task EditGrade(Grade grade)
        {
            CultureInfo customCulture = new CultureInfo("pl-PL");
            var dateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");          
            grade.AddDate = DateTime.ParseExact(dateTime, "dd-MM-yyyy HH:mm:ss", null);         
            grade.IsActive = true;
            _flowContext.Grades.Update(grade);
            await _flowContext.SaveChangesAsync();
        }

        public async Task RemoveGrade(Grade grade)
        {
            grade.IsActive = false;
            _flowContext.Grades.Update(grade);
            await _flowContext.SaveChangesAsync();
        }
    }
}
