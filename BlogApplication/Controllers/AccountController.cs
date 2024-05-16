using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
