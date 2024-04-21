using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class TeacherInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherInfoController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: List of all teachers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var teacherInfo = await _context.TeacherClassRelations
                .Include(tcr => tcr.Teacher)
                .Include(tcr=>tcr.Class)
                .GroupBy(tcr=>tcr.Teacher.TeacherFirstName)
                .Select(group=> new TeacherInfoViewModel
                {
                    TeacherName = group.Key,
                    TeachesClass = group.First().Teacher.Classes.Select(cl=>cl.Class.ClassName).ToList(),
                    TeachesCourse = group.First().Teacher.Courses.Select(c=>c.Course.CourseName).ToList(),
                }).ToListAsync();
            return View(teacherInfo);
        }
    }
}
