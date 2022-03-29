using LestsCodeEscola.Comum;
using System;
using System.Collections.Generic;

namespace LestsCodeEscola.Estudante.Entidades
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public Guid TurmaId { get; set; }
        public List<Nota.Entidades.Nota> Notas { get; set; } = new();

        public Aluno(string nome, int idade, string cpf, Guid turmaId)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            TurmaId = turmaId;
        }

        public void Atualizar(string novoNome, int novaIdade, Guid turmaId)
        {
            Nome = novoNome;
            Idade = novaIdade;
            TurmaId = turmaId;
        }

        public void AdicionarNota(Nota.Entidades.Nota nota)
        {
            Notas.Add(nota);
        }
    }
}
