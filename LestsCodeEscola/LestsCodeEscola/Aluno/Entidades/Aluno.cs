using LestsCodeEscola.Comum;
using System;
using System.Collections.Generic;

namespace LestsCodeEscola.Aluno.Entidades
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public List<Nota.Entidades.Nota> Notas { get; set; } = new();
        public Guid TurmaId { get; set; }
        //public virtual Turma Turma { get; set; }

        public Aluno(string nome, int idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }

        public void Atualizar(string novoNome, int novaIdade)
        {
            Nome = novoNome;
            Idade = novaIdade;
        }

        public void AdicionarNota(Nota.Entidades.Nota nota)
        {
            Notas.Add(nota);
        }
    }
}
