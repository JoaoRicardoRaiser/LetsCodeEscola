using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Professor.Entidades
{
    public class Professor : EntidadeBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Disciplina { get; set; }
        public string Cpf { get; set; }
        public Guid AulaId { get; set; }

        public Professor(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}
