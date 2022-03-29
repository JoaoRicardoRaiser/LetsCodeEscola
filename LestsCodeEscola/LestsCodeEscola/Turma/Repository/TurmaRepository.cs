using AtividadeScrumLetsCode.Repositories;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Aula.Repository
{
    public class TurmaRepository : GenericRepository<Entidades.Turma>
    {
        public TurmaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Turma\Database\turmas.json";
        }

        public Entidades.Turma ObterPorDisciplina(string disciplina)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.Disciplina == disciplina);
        }

        public Entidades.Turma ObterPorTurma(string turma)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.NomeTurma == turma);
        }
    }
}