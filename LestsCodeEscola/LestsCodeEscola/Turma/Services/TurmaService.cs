using LestsCodeEscola.Aula.Repository;
using System;
using System.Threading;

namespace LestsCodeEscola.Aula.Services
{
    public class TurmaService
    {
        private TurmaRepository _turmaRepository { get; set; }

        public TurmaService()
        {
            _turmaRepository = new TurmaRepository();
        }


        public void Menu()
        {
            Console.Title = "Menu Turma";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao menu da Turma\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - Consulta de turmas");
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
            Console.WriteLine("2 - Consultar todas as turmas");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Digite a turma para consultar as aulas: ");
                    var turma = Console.ReadLine().ToUpper();
                    var aulasDaTurma = _turmaRepository.ObterPorTurma(turma);
                    if (aulasDaTurma != null)
                        Console.WriteLine($"Disciplina: {aulasDaTurma.Disciplina}\nHorario: {aulasDaTurma.Horario}\n");
                    else
                        Console.WriteLine("Turma não encontrada");
                    break;

                case "2":
                    var todasTurmas = _turmaRepository.GetAll();
                    foreach (var turmaSalva in todasTurmas)
                    {
                        Console.WriteLine($"Disciplina: {turmaSalva.Disciplina}\nHorario: {turmaSalva.Horario}\nTurma: { turmaSalva.NomeTurma}\n");
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

            Console.Write("Digite o nome do Aluno: ");
            var nomeAluno = Console.ReadLine();

            Console.Write("Digite a turma: ");
            var nomeTurma = Console.ReadLine().ToUpper();

            Console.Write("Digite o horário: ");
            var hora = Console.ReadLine();

            var turma = new Entidades.Turma(disciplina, nomeAluno, nomeTurma, hora);

            _turmaRepository.Criar(turma);
            Console.WriteLine("Cadastro Concluído.");
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite a turma que deseja editar: ");
            var disciplina = Console.ReadLine().ToUpper();

            var turmaSalva = _turmaRepository.ObterPorDisciplina(disciplina);

            if (turmaSalva != null)
            {
                Console.WriteLine("\nDisciplina encontrada\n");
                Console.WriteLine($"**** Disciplina: {turmaSalva.Disciplina}\nTurma: " +
                    $"{turmaSalva.NomeTurma}\nAluno: {turmaSalva.NomeAluno}\nHorário: {turmaSalva.Horario} ****\n");

                Console.WriteLine("\nDigite o novo nome da disciplina: ");
                var disciplinaNova = Console.ReadLine().ToUpper();

                Console.WriteLine("\nDigite o novo nome do Aluno: ");
                var nomeAluno = Console.ReadLine();

                Console.WriteLine("\nDigite o novo nome da turma: ");
                var turma = Console.ReadLine().ToUpper();

                Console.WriteLine("\nDigite o novo horário: ");
                var hora = Console.ReadLine();

                turmaSalva.Atualizar(disciplinaNova, nomeAluno, turma, hora);


                _turmaRepository.Atualizar(turmaSalva);
                Console.WriteLine("Atualização Conclúida.");
            }
            else
            {
                Console.WriteLine("Turma não encontrada");
                Thread.Sleep(1000);
                Menu();
            }
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite a turma a deletar: ");
            var disciplina = Console.ReadLine().ToUpper();

            var turmaSalva = _turmaRepository.ObterPorDisciplina(disciplina);

            if (turmaSalva != null)
            {
                Console.WriteLine("\nDisciplina encontrada\n");
                Console.WriteLine($"**** Disciplina: {turmaSalva.Disciplina} ****\n");

                _turmaRepository.Deletar(turmaSalva);
                Console.WriteLine("Registro Excluído.");
            }
            else
            {
                Console.WriteLine("Turma não encontrada");
                Thread.Sleep(1000);
                Menu();
            }
        }

    }
}
