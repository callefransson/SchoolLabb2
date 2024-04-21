using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class GetTeachersForCourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetTeachersForCourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: Courses
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }
        //POST: Search
        [HttpPost]
        public async Task<IActionResult> Search(int? courseId)
        {
            if (courseId != null)
            {
                var teacherResult = await _context.TeacherCourseRelations
                    .Include(tcr => tcr.Teacher)
                    .Include(tcr => tcr.Course)
                    .Where(tcr => tcr.Course.CourseId == courseId)
                    .Select(tcr => new TeacherCourseViewModel
                    {
                        TeacherName = tcr.Teacher.TeacherFirstName,
                        CourseName = tcr.Course.CourseName,
                    })
                    .ToListAsync();
                return View(teacherResult);
            }
            return View();
        }
    }
}
