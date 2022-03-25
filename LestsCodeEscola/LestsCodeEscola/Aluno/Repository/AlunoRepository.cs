using AtividadeScrumLetsCode.Repositories;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Aluno.Repository
{
    public class AlunoRepository : GenericRepository<Entidades.Aluno>
    {
        public AlunoRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Aluno\Database\alunos.json";
        }

        public Entidades.Aluno ObterPorCpf(string cpf)
        {
            var database = GetDatabase();
            return database.SingleOrDefault(x => x.Cpf == cpf);
        }

        public void AdicionarNotaParaAluno(Entidades.Aluno aluno, Nota.Entidades.Nota nota)
        {
            var database = GetDatabase();
            var alunoSalvo = database.SingleOrDefault(x => x.Id == aluno.Id);
            database.Remove(alunoSalvo);

            aluno.Notas.Add(nota);
            database.Add(aluno);
            UpdateDatabase(database);
        }
    }
}
