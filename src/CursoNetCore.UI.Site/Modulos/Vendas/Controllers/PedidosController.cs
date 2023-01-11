using Microsoft.AspNetCore.Mvc;

namespace CursoNetCore.UI.Site.Modulos.Vendas.Controllers
{
    public class PedidosController : Controller
    {
        [Area("Vendas")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
