using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SchoolLabb2.Data;
using SchoolLabb2.Models;

namespace SchoolLabb2.Controllers
{
    public class AddTeacherToClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddTeacherToClassController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName");
            ViewData["FkClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int teacherId, int classId)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t=>t.TeacherId == teacherId);
            var classObj = await _context.Classes.FirstOrDefaultAsync(c=>c.ClassId == classId);
            if(teacher == null)
            {
                return NotFound();
            }
            var teacherClassRelation = new TeacherClassRelation
            {
                FkTeacherId = teacherId,
                FkClassId = classId
            };
            _context.TeacherClassRelations.Add(teacherClassRelation);
            _context.SaveChanges();
            return RedirectToAction("Index","TeacherInfo");
        }
    }
}
