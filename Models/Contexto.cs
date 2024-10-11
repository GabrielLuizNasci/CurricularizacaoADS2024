﻿using Microsoft.EntityFrameworkCore;

namespace CurricularizacaoADS2024.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Professor> Professores { get; set; }
    }
}
