using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class UniversityContext: DbContext
    {
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }
    }
}
