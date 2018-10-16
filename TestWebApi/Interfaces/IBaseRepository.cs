using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWebApi.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAsync();
        Task<T> PutAsync(T obj);
        Task<T> PostAsync(T obj);
        Task<List<string>> GetNamesAsync();
        Task Delete(int id);
    }
}
