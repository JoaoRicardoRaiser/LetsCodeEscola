using AtividadeScrumLetsCode.Repositories;
using LestsCodeEscola.Professor.Entidades;
using System.IO;
using System.Linq;

namespace LestsCodeEscola.Professor.Repository
{
    public class ChamadaRepository : GenericRepository<Chamada>
    {
        public ChamadaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\professor\Database\chamada.json";
        }
    }
}
