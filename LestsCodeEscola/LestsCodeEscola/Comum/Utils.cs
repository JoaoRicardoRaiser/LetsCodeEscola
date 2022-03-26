using LestsCodeEscola.Aula.Entidades;
using LestsCodeEscola.Estudante.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LestsCodeEscola.Comum
{
    public static class Utils
    {
        public static void MostrarTurmas(List<Turma> turmas)
        {
            Parallel.ForEach(turmas, turma =>
            {
                Console.WriteLine($"\nDisciplina: {turma.Disciplina}\nNome: {turma.NomeTurma}\nHorario: {turma.Horario}\n");
            });
        }

        public static void MostrarAlunos(List<Aluno> alunos)
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"\nNome: {aluno.Nome}\nIdade: {aluno.Idade}\nCpf: {aluno.Cpf}\nTurmaId: {aluno.TurmaId}");
            }
        }

        public static void MostarAlunoEncontrado(Aluno aluno)
        {
            Console.WriteLine("Aluno encontrado\n");
            Console.WriteLine($"**** Nome: {aluno.Nome}\nIdade: {aluno.Idade}\n****\n");
        }
    }
}
