using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
