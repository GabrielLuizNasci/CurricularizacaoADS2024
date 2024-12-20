﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurricularizacaoADS2024.Models;

namespace CurricularizacaoADS2024.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly Contexto _context;

        public MatriculasController(Contexto context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Matriculas.Include(m => m.aluno).Include(m => m.curso).Include(m => m.turma);
            return View(await contexto.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.aluno)
                .Include(m => m.curso)
                .Include(m => m.turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["cursoID"] = new SelectList(_context.Cursos, "Id", "Nome");
            ViewData["turmaID"] = new SelectList(_context.Turma, "Id", "descricao");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataMatricula,cursoID,alunoID,RA,turmaID")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome", matricula.alunoID);
            ViewData["cursoID"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.cursoID);
            ViewData["turmaID"] = new SelectList(_context.Turma, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome", matricula.alunoID);
            ViewData["cursoID"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.cursoID);
            ViewData["turmaID"] = new SelectList(_context.Turma, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataMatricula,cursoID,alunoID,RA,turmaID")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome", matricula.alunoID);
            ViewData["cursoID"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.cursoID);
            ViewData["turmaID"] = new SelectList(_context.Turma, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.aluno)
                .Include(m => m.curso)
                .Include(m => m.turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
