using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Nota.Entidades
{
    public class Nota : EntidadeBase
    {


        public Nota(double valorNota, Guid alunoId, Guid professorId, string disciplina)
        {
            ValorNota = valorNota;
            AlunoId = alunoId;
            ProfessorId = professorId;
            Disciplina = disciplina;
        }
    }
}
