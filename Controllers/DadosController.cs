using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurricularizacaoADS2024.Models;

namespace CurricularizacaoADS2024.Controllers
{
    public class DadosController : Controller
    {

        private readonly Contexto contexto;

        public DadosController (Contexto context)
        {
            contexto = context;
        }

        public IActionResult Visitas ()
        {
            Random rand = new Random ();
            contexto.Database.ExecuteSqlRaw("delete from Visitas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Visitas', RESEED, 0)");

            for (int i = 0; i < 100; i++)
            {
                Visita visita = new Visita();
                //visita.Id = i;
                visita.responsavelID = rand.Next (1, 5);
                visita.datavisita = Convert.ToDateTime("01/01/1956").AddDays(rand.Next(1,18260));
                visita.descricao ="Descrito " + i.ToString();
                visita.status = rand.Next(1, 3);

                contexto.Visitas.Add (visita);

            }
            contexto.SaveChanges();

            return View(contexto.Visitas.Include(v => v.responsavel).ToList());
        }
    }
}
