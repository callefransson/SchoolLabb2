using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: List of all students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Creating a join to join students and classes to ClassStudentRelation table
            var studentInfo = await _context.Students
                .Join(_context.ClassStudentRelation,
                    student => student.StudentId,
                    csr => csr.FkStudentId,
                    (student, csr) => new { Student = student, ClassStudentRelation = csr })
                .Join(_context.Classes,
                    scj => scj.ClassStudentRelation.FkClassId,
                    classObj => classObj.ClassId,
                    (scj, classObj) => new StudentInfoViewModel
                    {
                        StudentFirstName = scj.Student.StudentFirstName,
                        StudentLastName = scj.Student.StudentLastName,
                        ClassName = classObj.ClassName,
                        ClassCourse = scj.Student.Courses.Select(c => c.Course.CourseName).ToList(),
                    })
                .ToListAsync();

            return View(studentInfo);
        }
        [HttpGet]
        public IActionResult Search()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Result(int? courseId)
        {
            if (courseId != null)
            {
                var studentResult = await _context.StudentCourseRelation
                    .Include(scr => scr.Student)
                    .Include(scr => scr.Course)
                        .ThenInclude(c => c.Teachers)
                    .Where(scr => scr.Course.CourseId == courseId)
                    .GroupBy(scr => scr.Student.StudentFirstName)
            .Select(group => new StudentCourseViewModel
            {
                StudentName = group.Key,
                CourseName = group.First().Course.CourseName,
                TeacherName = string.Join(", ", group.SelectMany(scr => scr.Course.Teachers.Select(tcr => tcr.Teacher.TeacherFirstName)))
            })
            .ToListAsync();
                return View(studentResult);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {

            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName");
            return View();
        }
    }
}
