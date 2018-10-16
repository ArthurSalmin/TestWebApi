using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Interfaces
{
    public interface IStudentRepository : IBaseRepository<StudentModel>
    {
        Task<List<string>> GetNamesAsync();
        Task<List<StudentModel>> GetStudentsByGroupIdAsync(int groupId);
    }
}
