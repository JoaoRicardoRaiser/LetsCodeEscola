using LestsCodeEscola.Comum;
using System.Collections.Generic;

namespace LestsCodeEscola.Professor.Entidades
{
    public class Chamada : EntidadeBase
    {
        public string Turma { get; set; }
        public List<string> alunos;
        public bool Finalizada { get; set; } = false;
        public string Data { get; set; }
    }
}
