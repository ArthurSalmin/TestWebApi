using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityContext _dbContext;
        public StudentRepository(UniversityContext context)
        {
            _dbContext = context;
            if (!_dbContext.Students.Any())
            {
                _dbContext.Students.Add(new StudentModel { Group_id = 1, Name = "Arthur"  });
                _dbContext.Students.Add(new StudentModel { Group_id = 2, Name = "Andrew" });
                _dbContext.Students.Add(new StudentModel { Group_id = 3, Name = "Alex" });
                _dbContext.SaveChanges();
            }
        }
        public async Task Delete(int id)
        {
            StudentModel student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<StudentModel>> GetAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<StudentModel> GetAsync(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<string>> GetNamesAsync()
        {
            return await _dbContext.Students.Select(x => x.Name).ToListAsync();
        }

        public async Task<List<StudentModel>> GetStudentsByGroupIdAsync(int groupId)
        {
            return await _dbContext.Students.Where(x => x.Group_id == groupId).ToListAsync();
        }

        public async Task<StudentModel> PostAsync(StudentModel obj)
        {
            await _dbContext.Students.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<StudentModel> PutAsync(StudentModel obj)
        {
            if (!_dbContext.Students.Any(x => x.Id == obj.Id))
            {
                return null;
            }
            _dbContext.Update(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

    }
}
