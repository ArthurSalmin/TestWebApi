using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Interfaces
{
    public interface IStudentRepository : IBaseRepository<StudentModel>
    {
        Task<List<StudentModel>> GetStudentsByGroupIdAsync(int groupId);
    }
}
