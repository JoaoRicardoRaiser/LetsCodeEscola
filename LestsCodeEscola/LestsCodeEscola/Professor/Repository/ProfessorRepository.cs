using AtividadeScrumLetsCode.Repositories;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Professor.Repository
{
    public class ProfessorRepository : GenericRepository<Entidades.Professor>
    {
        public ProfessorRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\professor\Database\professores.json";
        }

        public Entidades.Professor ObterPorCpf(string cpf)
        {
            var database = GetDatabase();
            return database.SingleOrDefault(x => x.Cpf == cpf);
        }
    }
}
