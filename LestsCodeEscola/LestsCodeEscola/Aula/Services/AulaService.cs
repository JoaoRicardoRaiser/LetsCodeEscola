using LestsCodeEscola.Aula.Repository;
using System;
using System.Threading;

namespace LestsCodeEscola.Aula.Services
{
    public class AulaService
    {
        private AulaRepository _aulaRepository { get; set; }

        public AulaService()
        {
            _aulaRepository = new AulaRepository();
        }


        public void Menu()
        {
            Console.Title = "Menu Aula";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao menu de Aula\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - Consultar aulas da turma");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine("0 - Voltar\n");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Consultar();
                    break;

                case "2":
                    Cadastrar();
                    break;

                case "3":
                    Editar();
                    break;

                case "4":
                    Deletar();
                    break;

                case "0":
                    MenuPrincipal.Iniciar();
                    break;

                default:
                    Console.WriteLine("\nOpção invalida, tente novamente...\n");
                    Thread.Sleep(2000);
                    Menu();
                    break;
            }
        }

        public void Consultar()
        {
            var aulasDaTurma = _aulaRepository.GetAll();
            foreach (var aula in aulasDaTurma)
            {
                Console.WriteLine($"Disciplina: {aula.Disciplina}\nHorario: {aula.Horario}\n");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            Console.Write("Digite a disciplina: ");
            var disciplina = Console.ReadLine();

            Console.Write("Digite o nome do Professor: ");
            var nomeProfessor = Console.ReadLine();

            Console.Write("Digite a turma: ");
            var turma = Console.ReadLine();

            Console.Write("Digite o horário: ");
            var hora = Console.ReadLine();

            var aula = new Entidades.Aula(disciplina, nomeProfessor, turma, hora);

            _aulaRepository.Criar(aula);
            Console.WriteLine("Cadastro Conclúido.");
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite a disciplina editar: ");
            var disciplina = Console.ReadLine();

            var aulaSalva = _aulaRepository.ObterPorDisciplina(disciplina);

            Console.WriteLine("\nDisciplina encontrada\n");
            Console.WriteLine($"**** Disciplina: {aulaSalva.Disciplina}\nTurma: {aulaSalva.Turma}\nProfessor: {aulaSalva.NomeProfessor}\nHorário: {aulaSalva.Horario} ****\n");

            Console.WriteLine("\nDigite o novo nome da aula: ");
            var disciplinaNova = Console.ReadLine();

            Console.WriteLine("\nDigite o novo nome do Professor: ");
            var nomeProfessor = Console.ReadLine();

            Console.WriteLine("\nDigite o novo nome da turma: ");
            var turma = Console.ReadLine();

            Console.WriteLine("\nDigite o novo horário: ");
            var hora = Console.ReadLine();

            aulaSalva.Atualizar(disciplinaNova, nomeProfessor, turma, hora);


            _aulaRepository.Atualizar(aulaSalva);
            Console.WriteLine("Atualização Conclúida.");
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite a disciplina deletar: ");
            var disciplina = Console.ReadLine();

            var aulaSalvo = _aulaRepository.ObterPorDisciplina(disciplina);

            Console.WriteLine("\nDisciplina encontrada\n");
            Console.WriteLine($"**** Disciplina: {aulaSalvo.Disciplina} ****\n");

            _aulaRepository.Deletar(aulaSalvo);
        }

    }
}
