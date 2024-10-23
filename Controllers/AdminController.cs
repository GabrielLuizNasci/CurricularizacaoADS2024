using Microsoft.AspNetCore.Mvc;

namespace CurricularizacaoADS2024.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
