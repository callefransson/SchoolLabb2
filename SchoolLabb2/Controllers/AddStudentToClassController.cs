using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class AddStudentToClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddStudentToClassController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        // GET: AddStudentToClass/Create
        public IActionResult Create()
        {
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentFirstName");
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int studentId, int classId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
            var classObj = await _context.Classes.FirstOrDefaultAsync(c => c.ClassId == classId);
            if (student == null || classObj == null)
            {
                return NotFound();
            }
            var studentClassRelation = new ClassStudentRelation
            {
                FkClassId = classId,
                FkStudentId = studentId,
            };
            _context.ClassStudentRelation.Add(studentClassRelation);
            _context.SaveChanges();
            return RedirectToAction("Index" , "StudentInfo");
        }
    }
}
