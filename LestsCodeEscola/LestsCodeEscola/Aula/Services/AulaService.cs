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
            Console.WriteLine("1 - Consulta de aulas");
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
            Console.Clear();
            Console.WriteLine("Digite a tipo de consulta que você deseja\n");
            Console.WriteLine("1 - Consultar aulas da turma");
            Console.WriteLine("2 - Consultar todas as aulas");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Digite a turma para consultar as aulas: ");
                    var turma = Console.ReadLine().ToUpper();
                    var aulasDaTurma = _aulaRepository.ObterPorTurma(turma);
                    if (aulasDaTurma != null)
                        Console.WriteLine($"Disciplina: {aulasDaTurma.Disciplina}\nHorario: {aulasDaTurma.Horario}\n");
                    else
                        Console.WriteLine("Turma não encontrada");
                    break;

                case "2":
                    var todasAulas = _aulaRepository.GetAll();
                    foreach (var aula in todasAulas)
                    {
                        Console.WriteLine($"Disciplina: {aula.Disciplina}\nHorario: {aula.Horario}\nTurma: { aula.Turma}\n");
                    }
                    break;

                default:
                    Console.WriteLine("\nOpção invalida, tente novamente...\n");
                    Thread.Sleep(1000);
                    Menu();
                    break;
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            Console.Write("Digite a disciplina: ");
            var disciplina = Console.ReadLine().ToUpper();

            Console.Write("Digite o nome do Professor: ");
            var nomeProfessor = Console.ReadLine();

            Console.Write("Digite a turma: ");
            var turma = Console.ReadLine().ToUpper();

            Console.Write("Digite o horário: ");
            var hora = Console.ReadLine();

            var aula = new Entidades.Aula(disciplina, nomeProfessor, turma, hora);

            _aulaRepository.Criar(aula);
            Console.WriteLine("Cadastro Concluído.");
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite a aula que deseja editar: ");
            var disciplina = Console.ReadLine().ToUpper();

            var aulaSalva = _aulaRepository.ObterPorDisciplina(disciplina);

            if (aulaSalva != null)
            {
                Console.WriteLine("\nDisciplina encontrada\n");
                Console.WriteLine($"**** Disciplina: {aulaSalva.Disciplina}\nTurma: " +
                    $"{aulaSalva.Turma}\nProfessor: {aulaSalva.NomeProfessor}\nHorário: {aulaSalva.Horario} ****\n");

                Console.WriteLine("\nDigite o novo nome da aula: ");
                var disciplinaNova = Console.ReadLine().ToUpper();

                Console.WriteLine("\nDigite o novo nome do Professor: ");
                var nomeProfessor = Console.ReadLine();

                Console.WriteLine("\nDigite o novo nome da turma: ");
                var turma = Console.ReadLine().ToUpper();

                Console.WriteLine("\nDigite o novo horário: ");
                var hora = Console.ReadLine();

                aulaSalva.Atualizar(disciplinaNova, nomeProfessor, turma, hora);


                _aulaRepository.Atualizar(aulaSalva);
                Console.WriteLine("Atualização Conclúida.");
            }
            else
            {
                Console.WriteLine("Aula não encontrada");
                Thread.Sleep(1000);
                Menu();
            }
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite a aula deletar: ");
            var disciplina = Console.ReadLine().ToUpper();

            var aulaSalva = _aulaRepository.ObterPorDisciplina(disciplina);

            if (aulaSalva != null)
            {
                Console.WriteLine("\nDisciplina encontrada\n");
                Console.WriteLine($"**** Disciplina: {aulaSalva.Disciplina} ****\n");

                _aulaRepository.Deletar(aulaSalva);
                Console.WriteLine("Registro Excluído.");
            }
            else
            {
                Console.WriteLine("Aula não encontrada");
                Thread.Sleep(1000);
                Menu();
            }
        }

    }
}
