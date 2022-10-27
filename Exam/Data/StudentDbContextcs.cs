using Exam.Model;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data
{
    public class StudentDbContextcsDb : DbContext
    {
        public StudentDbContextcsDb(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<Student> students { get; set; }
    }
}
