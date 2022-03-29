using AtividadeScrumLetsCode.Repositories;
using LestsCodeEscola.Estudante.Entidades;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Estudante.Repository
{
    public class AlunoRepository: GenericRepository<Aluno>
    {
        public AlunoRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Estudante\Database\alunos.json";
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
