using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class AddTeacherToCourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddTeacherToCourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName");
            ViewData["FKCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int teacherId, int courseId)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);
            var course = await _context.Courses.FirstOrDefaultAsync(c=>c.CourseId == courseId);
           
            if (teacher == null || course == null) 
            {
                return NotFound();
            }
            var teacherToCourse = new TeacherCourseRelation
            {
                FkTeacherId = teacherId,
                FkCourseId = courseId
            };
            _context.TeacherCourseRelations.Add(teacherToCourse);
            _context.SaveChanges();
            return RedirectToAction("Index", "TeacherInfo");
        }
        
    }
}
