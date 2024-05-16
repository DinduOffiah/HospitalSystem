using BlogApplication.Data;
using BlogApplication.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ArticlesController( ApplicationDbContext context) 
        {
            _context = context;
        }
        // GET: ArticlesController
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

        // GET: ArticlesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var article = await _context.articles.FirstOrDefaultAsync(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article); 
        }


        // GET: ArticlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogApplication.Models.Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.articles.Add(article);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: ArticlesController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var article = await _context.articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogApplication.Models.Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var existingNews = await _context.articles.FindAsync(id);

                    existingNews.Title = article.Title;
                    existingNews.Image = article.Image;
                    existingNews.Story = article.Story;
                    existingNews.Date = article.Date;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(article);
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticlesController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.articles.FirstOrDefaultAsync(m => m.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: ArticlesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.articles.Remove(article);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
