using LestsCodeEscola.Aluno.Repository;
using LestsCodeEscola.Professor.Repository;
using System;
using System.Threading;

namespace LestsCodeEscola.Professor.Services
{
    public class ProfessorService
    {
        private ProfessorRepository _professorRepository { get; set; }

        public ProfessorService()
        {
            _professorRepository = new ProfessorRepository();
        }

        public void Menu()
        {
            Console.Title = "Menu Professor";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao menu de Professor\n");
            while (true)
            {
                Console.WriteLine("Digite a opção que você deseja\n");
                Console.WriteLine("1 - Buscar");
                Console.WriteLine("2 - Cadastrar");
                Console.WriteLine("3 - Editar");
                Console.WriteLine("4 - Deletar");
                Console.WriteLine("5 - Menu de Chamada");
                Console.WriteLine("0 - Voltar\n");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Buscar();
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
                        this.Menu();
                        break;
                }
            }
        }

        public void MenuPresenca()
        {
            Console.Title = "Chamada";
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Digite a opção que você deseja\n");
                Console.WriteLine("1 - Inserir Presença de Aluno");
                Console.WriteLine("2 - Finalizar Chamada de Hoje");
                Console.WriteLine("0 - Voltar\n");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        // Criar Metodo Que integra aula para inserir alunos
                        break;

                    case "2":
                        // Criar Metodo Que finaliza chamada
                        break;

                    case "0":
                        this.Menu();
                        break;

                    default:
                        Console.WriteLine("\nOpção invalida, tente novamente...\n");
                        Thread.Sleep(2000);
                        this.MenuPresenca();
                        break;
                }
            }
        }

        public void Buscar()
        {
            var professoresSalvos = _professorRepository.GetAll();
            foreach (var professor in professoresSalvos)
            {
                Console.WriteLine($"Nome: {professor.Nome}\nIdade: {professor.Disciplina}\n");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();

            Console.Write("Digite a Disciplina: ");
            var disciplina = Console.ReadLine();

            Console.Write("Digite a cpf: ");
            var cpf = Console.ReadLine();

            var aluno = new Entidades.Professor(nome, disciplina, cpf);

            _professorRepository.Criar(aluno);
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var professorSalvo = _professorRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {professorSalvo.Nome}\nDisciplina: {professorSalvo.Disciplina} ****\n");

            Console.WriteLine("\nDigite o novo nome: ");
            var novoNome = Console.ReadLine();

            Console.Write("Digite a Disciplina: ");
            var disciplina = Console.ReadLine();

            professorSalvo.Atualizar(novoNome, disciplina);

            _professorRepository.Atualizar(professorSalvo);
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do professor (sem . e -): ");
            var cpf = Console.ReadLine();

            var alunoSalvo = _professorRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {alunoSalvo.Nome}\nIdade: {alunoSalvo.Disciplina} ****\n");

            _professorRepository.Deletar(alunoSalvo);
        }
    }
}
