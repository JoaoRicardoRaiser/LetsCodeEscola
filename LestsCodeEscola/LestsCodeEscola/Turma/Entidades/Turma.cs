using LestsCodeEscola.Comum;

namespace LestsCodeEscola.Aula.Entidades
{
    public class Turma : EntidadeBase
    {
        public string Disciplina { get; set; }
        public string NomeAluno { get; set; }
        public string NomeTurma { get; set; }
        public string Horario { get; set; }

        public Turma(string disciplina, string nomeAluno, string nomeTurma, string horario)
        {
            Disciplina = disciplina;
            NomeAluno = nomeAluno;
            NomeTurma = nomeTurma;
            Horario = horario;
        }

        public void Atualizar(string disciplinaNova, string nomeAluno, string turma, string hora)
        {
            Disciplina = disciplinaNova;
            NomeAluno = nomeAluno;
            NomeTurma = turma;
            Horario = hora;

        }
    }
}