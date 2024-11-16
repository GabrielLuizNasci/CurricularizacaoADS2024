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

        public IActionResult FiltrarMatricula ()
        { 
            return View(); 
        }


        public IActionResult ResFiltraMatricula(int? id, string nome)
        {
            List<Matricula> listaMatricula;

            if (id != null)
            {
                listaMatricula = contexto.Matriculas
                    .Include(a => a.aluno)
                    .Include(a => a.turma)
                    .Include(a => a.curso)
                    .Where(a => a.Id == id)
                    .ToList();
            }

            else
                if(!nome.IsNullOrEmpty()) 
            {
                listaMatricula = contexto.Matriculas
                    .Include(a => a.aluno)
                    .Include(a => a.turma)
                    .Include(a => a.curso)
                    .Where(n => n.aluno.Nome.Contains(nome)). OrderBy(o=>o.aluno.Nome)
                    .ToList();
            }

            else
            {
                listaMatricula = contexto.Matriculas
                    .Include(a => a.aluno)
                    .Include(a => a.turma)
                    .Include(a => a.curso)
                    .ToList();
            }

            return View(listaMatricula);
        }



    }
}
