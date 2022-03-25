using AtividadeScrumLetsCode.Repositories;
using System.IO;

namespace LestsCodeEscola.Nota.Repository
{
    public class NotaRepository : GenericRepository<Entidades.Nota>
    {
        public NotaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"\Nota\Database\nota.json";
        }
    }
}
