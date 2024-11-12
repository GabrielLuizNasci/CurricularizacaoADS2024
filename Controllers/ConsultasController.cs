using CurricularizacaoADS2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CurricularizacaoADS2024.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Contexto contexto;

        public ConsultasController(Contexto context)
        {
            contexto = context;
        }
        public IActionResult FiltrarVisita ()
        {
            return View();
        }

        public IActionResult ResFiltrarVisita(int ?id, string nome) 
        { 
            List<Visita> listaVisitas = new List<Visita>();
            if (id != null)
               listaVisitas = contexto.Visitas.Include(t=>t.responsavel).Where(t => t.Id==id).ToList();

            else 
                if (! nome.IsNullOrEmpty())
                //listaVisitas = contexto.Visitas.Include(t => t.responsavel).Where(n=> n.responsavel.nome == nome).ToList();
                listaVisitas = contexto.Visitas.Include(t => t.responsavel).Where(n=> n.responsavel.nome.Contains(nome)).OrderBy(o=>o.responsavel.nome).ToList();
                 else
                        listaVisitas = contexto.Visitas.Include(t => t.responsavel).ToList();

            return View(listaVisitas);
        }
    }
}
