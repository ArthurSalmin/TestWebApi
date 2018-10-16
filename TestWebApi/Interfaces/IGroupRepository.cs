using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Interfaces
{
    public interface IGroupRepository : IBaseRepository<GroupModel>
    {
        Task<List<string>> GetNamesAsync();
    }
}
