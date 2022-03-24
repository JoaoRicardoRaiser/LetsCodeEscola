using LestsCodeEscola.Comum;

namespace LestsCodeEscola.Aula.Entidades
{
    public class Aula : EntidadeBase
    {
        public string Disciplina { get; set; }
        public string NomeProfessor { get; set; }
        public string Turma { get; set; }
        public string Horario { get; set; }

        public Aula(string disciplina, string nomeProfessor, string turma, string horario)
        {
            Disciplina = disciplina;
            NomeProfessor = nomeProfessor;
            Turma = turma;
            Horario = horario;
        }

        public void Atualizar(string disciplinaNova, string nomeProfessor, string turma, string hora)
        {
            Disciplina = disciplinaNova;
            NomeProfessor = nomeProfessor;
            Turma = turma;
            Horario = hora;

        }
    }
}
