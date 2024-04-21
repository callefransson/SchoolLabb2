using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Models;

namespace SchoolLabb2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassStudentRelation> ClassStudentRelation { get; set; }
        public DbSet<TeacherClassRelation> TeacherClassRelations { get; set; }
        public DbSet<TeacherCourseRelation> TeacherCourseRelations { get; set; }
        public DbSet<StudentCourseRelation> StudentCourseRelation { get; set; }
    }
}
