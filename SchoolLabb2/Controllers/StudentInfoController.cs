using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;
using System.Runtime.InteropServices.Marshalling;

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
                        .ThenInclude(c => c.TeacherCourses)
                    .Where(scr => scr.Course.CourseId == courseId)
                    .GroupBy(scr => scr.Student.StudentFirstName)
            .Select(group => new StudentCourseViewModel
            {
                StudentName = group.Key,
                CourseName = group.First().Course.CourseName,
                TeacherName = string.Join(", ", group.SelectMany(scr => scr.Course.TeacherCourses.Select(tcr => tcr.Teacher.TeacherFirstName)))
            })
            .ToListAsync();
                return View(studentResult);
            }
            return View();
        }
        [HttpGet]
        public IActionResult ChooseStudent()
        {
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentFirstName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChooseStudent(StudentInfoViewModel viewModel)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.StudentId == viewModel.StudentId);
            if (student == null)
            {
                return NotFound();
            }
            return RedirectToAction("ChooseCourse", student);
        }
        [HttpGet]
        public IActionResult ChooseCourse(int studentId)
        {
            var student = _context.Students
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            var courses = student.Courses.Select(sc => sc.Course).ToList();
            ViewData["FkCourseId"] = new SelectList(courses, "CourseId", "CourseName");
            return View();
        }
        [HttpGet]
        public IActionResult ChooseTeacher(int courseId, int studentId)
        {
            var teachers = _context.TeacherCourseRelations
                .Include(tcr => tcr.Teacher)
                .Where(tcr => tcr.Course.CourseId == courseId)
                .Select(tcr => tcr.Teacher)
                .Distinct()
                .ToList();

            ViewData["FkTeacherId"] = new SelectList(teachers, "TeacherId", "TeacherFirstName");
            ViewData["CourseId"] = courseId;
            ViewData["StudentId"] = studentId;

            return View();
        }
        [HttpPost]
        public IActionResult ChooseTeacher(int courseId, int studentId, int teacherId)
        {
            return RedirectToAction("ChooseAllTeachers", new { courseId = courseId, studentId = studentId, currentTeacherId = teacherId });
        }
        [HttpGet]
        public IActionResult ChooseAllTeachers(int courseId, int studentId)
        {
            var allTeachers = _context.Teachers.ToList();
            ViewData["FkTeacherId"] = new SelectList(allTeachers, "TeacherId", "TeacherFirstName");
            ViewData["CourseId"] = courseId;
            ViewData["StudentId"] = studentId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChooseAllTeachers(int courseId, int teacherId, int selectedTeacherId)
        {
            var teacherCourseRelation = await _context.TeacherCourseRelations
                .Where(tcr => tcr.Teacher.TeacherId == teacherId && tcr.Course.CourseId == courseId)
                .FirstOrDefaultAsync();
            var selectedTeacher = _context.Teachers.FirstOrDefaultAsync(t=>t.TeacherId == selectedTeacherId);
            if (teacherCourseRelation == null)
            {
                return NotFound();
            }
            //Remove that teacher from that course
                _context.TeacherCourseRelations.Remove(teacherCourseRelation);
                await _context.SaveChangesAsync();
                TeacherCourseRelation teacherCourse = new()
                {
                    FkTeacherId = teacherId,
                    FkCourseId = courseId,
                };
            //Add new teacher to teach in that course
                _context.TeacherCourseRelations.Add(teacherCourse);
                await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
