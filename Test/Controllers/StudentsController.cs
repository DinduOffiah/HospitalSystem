using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Test.Data;
using Test.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index(string query)
        {
            var studentData = string.IsNullOrEmpty(query)
            ? _context.Students.ToList()
            : _context.Students.Where(s => s.FirstName.Contains(query) || s.LastName.Contains(query)).ToList();
            return View(studentData);
        }


        //GET: Students/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Students/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("LastName,FirstName")] Student student)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    student.Photo = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }




        // GET: Students/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        // POST: Students/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile? file, Student student)
        {

            if (ModelState.IsValid)
            {

                var existingStudent = await _context.Students.FindAsync(id);

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;

                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        existingStudent.Photo = memoryStream.ToArray();
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }


        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.RegNo == id);
        }


        // GET: Students/Delete
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.RegNo == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Delete
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        ////GET : Students/Photo
        //[HttpPost]
        //public IActionResult Upload(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("File not selected.");

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        file.CopyTo(memoryStream);
        //        var imageData = new Student
        //        {
        //            FirstName = file.FileName,
        //            Photo = memoryStream.ToArray()
        //        };

        //        _context.Students.Add(imageData);
        //        _context.SaveChanges();

        //        return Content("Image uploaded successfully!");
        //    }
        //}

    }
}
