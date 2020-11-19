using Microsoft.AspNetCore.Mvc;

namespace Loja_Quadrinhos.Area.Admin.Controllers
{
    public class CategoriaAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
