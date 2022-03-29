using System;

namespace LestsCodeEscola.Professor.Entidades
{
    public class ChamadaBuilder
    {
        private Chamada _chamada;

        public ChamadaBuilder()
        {
            _chamada = new Chamada();
            _chamada.Data = DateTime.UtcNow.ToString("dd/mm/yyyy");
        }

        public ChamadaBuilder AddAluno(string nomeAluno)
        {
            _chamada.alunos.Add(nomeAluno);
            return this;
        }

        public ChamadaBuilder SetTurma(string turma)
        {
            _chamada.Turma = turma;
            return this;
        } 

        public Chamada FinalizarChamada()
        {
            _chamada.Finalizada = true;
            var chamada = _chamada;
            _chamada = new Chamada();

            return chamada;
        }
    }
}
