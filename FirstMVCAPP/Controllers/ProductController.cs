using Microsoft.AspNetCore.Mvc;

namespace FirstMVCAPP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
