using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Nota.Entidades
{
    public class Nota: EntidadeBase
    {
        protected Nota() { }

        public Guid AlunoId { get; set; }
        public float Valor { get; set; }
    }
}
