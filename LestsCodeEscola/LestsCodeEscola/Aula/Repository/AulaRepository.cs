using AtividadeScrumLetsCode.Repositories;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Aula.Repository
{
    public class AulaRepository : GenericRepository<Entidades.Aula>
    {
        public AulaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\aula\Database\aulas.json";
        }

        public Entidades.Aula ObterPorDisciplina(string disciplina)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.Disciplina == disciplina);
        }

        public Entidades.Aula ObterPorTurma(string turma)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.Turma == turma);
        }
    }
}
