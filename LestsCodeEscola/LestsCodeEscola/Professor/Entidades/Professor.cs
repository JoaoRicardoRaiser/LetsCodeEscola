using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Professor.Entidades
{
    public class Professor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Disciplina { get; set; }
        public string Cpf { get; set; }

        public Professor(string nome, string disciplina, string cpf)
        {
            Nome = nome;
            Disciplina = disciplina;
            Cpf = cpf;
        }

        public void Atualizar(string nome, string disciplina)
        {
            Nome = nome;
            Disciplina = disciplina;
        }
    }
}
