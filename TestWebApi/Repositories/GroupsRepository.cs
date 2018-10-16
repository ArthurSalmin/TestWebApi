using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.Interfaces;

namespace TestWebApi.Repositories
{
    public class GroupsRepository : IGroupRepository
    {
        private readonly UniversityContext _dbContext;
        public GroupsRepository(UniversityContext dbContext)
        {
            _dbContext = dbContext;
            if (!_dbContext.Groups.Any())
            {
                _dbContext.Groups.Add(new GroupModel { Name = "401" });
                _dbContext.Groups.Add(new GroupModel { Name = "402" });
                _dbContext.Groups.Add(new GroupModel { Name = "403" });
                _dbContext.SaveChanges();
            }
        }
        public async Task Delete(int id)
        {
            GroupModel group = _dbContext.Groups.FirstOrDefault(x => x.Id == id);
            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GroupModel>> GetAsync()
        {
            return await _dbContext.Groups.ToListAsync();
        }

        public async Task<GroupModel> GetAsync(int id)
        {
            return await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<string>> GetNamesAsync()
        {
            return await _dbContext.Groups.Select(x => x.Name).ToListAsync();
        }

        public async Task<GroupModel> PostAsync(GroupModel obj)
        {
            await _dbContext.Groups.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<GroupModel> PutAsync(GroupModel obj)
        {
            if (!_dbContext.Groups.Any(x => x.Id == obj.Id))
            {
                return null;
            }
            _dbContext.Update(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }


    }
}
