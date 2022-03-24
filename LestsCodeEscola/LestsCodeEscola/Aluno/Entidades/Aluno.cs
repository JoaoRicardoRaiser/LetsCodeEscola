using LestsCodeEscola.Comum;
using System;

namespace LestsCodeEscola.Aluno.Entidades
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        //public List<Nota> Notas { get; set; }
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
    }
}
