using BlogApplication.Data;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string query)
        {
            if (DateTime.TryParse(query, out DateTime searchDate))
            {
                // If the query is a valid date, search for records matching the date and order them by Date in descending order
                var studentData = _context.articles
                    .Where(s => s.Date.Date == searchDate.Date)
                    .OrderByDescending(s => s.Date)
                    .ToList();
                return View(studentData);
            }
            else
            {
                // If the query is not a valid date, search for records by title and order them by Date in descending order
                var studentData = string.IsNullOrEmpty(query)
                    ? _context.articles.OrderByDescending(s => s.Date).ToList()
                    : _context.articles
                        .Where(s => s.Title.Contains(query))
                        .OrderByDescending(s => s.Date)
                        .ToList();
                return View(studentData);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}