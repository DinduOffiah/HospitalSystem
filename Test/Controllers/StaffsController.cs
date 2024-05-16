using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class StaffsController : Controller
    {
        private readonly AppDbContext _context;

        public StaffsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var staffData = _context.Staffs.Select(s => new StaffViewModel
            {
                Name = s.Name,
                Designation = s.Designition
            }).ToList();

            return View(staffData);
        }



        //GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Staff/Create
        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.Add(staff);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }


    }
}
