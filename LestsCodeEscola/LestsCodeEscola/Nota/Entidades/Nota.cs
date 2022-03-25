using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Nota.Entidades
{
    public class Nota : EntidadeBase
    {
        public double ValorNota { get; set; }
        public Guid AlunoId { get; set; }
        public Guid ProfessorId { get; set; }
        public string Disciplina { get; set; }


        public Nota(double valorNota, Guid alunoId, Guid professorId, string disciplina)
        {
            ValorNota = valorNota;
            AlunoId = alunoId;
            ProfessorId = professorId;
            Disciplina = disciplina;
        }
    }
}
