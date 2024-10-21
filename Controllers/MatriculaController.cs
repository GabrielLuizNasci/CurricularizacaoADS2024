using Microsoft.AspNetCore.Mvc;

namespace CurricularizacaoADS2024.Controllers
{
    public class MatriculaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
    }
}
