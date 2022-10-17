using Microsoft.AspNetCore.Mvc;

namespace CursoNetCore.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
