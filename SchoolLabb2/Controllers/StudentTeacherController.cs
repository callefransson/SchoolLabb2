using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class StudentTeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentTeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Result()
        {
            var matchingTeachersAndStudents = await _context.TeacherClassRelations
            .Include(tcr => tcr.Teacher)
            .Include(tcr => tcr.Class)
            .Join(
                _context.ClassStudentRelation,
                tcr => tcr.Class.ClassId,
                csr => csr.FkClassId,
                (tcr, csr) => new { TeacherClassRelation = tcr, ClassStudentRelation = csr }
            )
            .Where(match => match.TeacherClassRelation.FkClassId == match.ClassStudentRelation.FkClassId)
            .GroupBy(match => new
            {
                match.ClassStudentRelation.Student.StudentId,
                match.ClassStudentRelation.Student.StudentFirstName
            })
            .Select(group => new TeacherStudentViewModel
            {
                StudentName = group.Key.StudentFirstName,
                TeacherName = group.Select(match => match.TeacherClassRelation.Teacher.TeacherFirstName).ToList()
            })
            .ToListAsync();
            return View(matchingTeachersAndStudents);
        }
    }
}
