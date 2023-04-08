using FlowPanelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.SchoolService
{
    public interface ISchoolService
    {
        Task<List<School>> GetAll();
        Task CreateSchool(School school);
        School GetSchoolById(long schoolID);
        Task UpdateSchool(School school);
        Task<string> GetSchoolNameBySchoolId(long schoolId);
    }
}
