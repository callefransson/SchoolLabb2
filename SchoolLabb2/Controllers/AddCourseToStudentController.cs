using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class AddCourseToStudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddCourseToStudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentFirstName");
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int studentId, int courseId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (student == null || course == null)
            {
                return NotFound();
            }
            var studentCourseRelation = new StudentCourseRelation
            {
                FkCourseId = courseId,
                FkStudentId = studentId,
            };
            _context.StudentCourseRelation.Add(studentCourseRelation);
            _context.SaveChanges();
            return RedirectToAction("Index", "StudentInfo");
        }
    }
}
