using Entity_FramesWork_Student_Course_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_FramesWork_Student_Course_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get Students with Course Details
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students
                                   .Include(s => s.Course)
                                   .ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("GetStudents");
        }

        


    }
}
