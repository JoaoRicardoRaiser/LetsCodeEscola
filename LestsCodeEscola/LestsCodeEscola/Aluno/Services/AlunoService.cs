using LestsCodeEscola.Aluno.Repository;
using System;
using System.Threading;

namespace LestsCodeEscola.Aluno.Services
{
    public class AlunoService
    {
        private AlunoRepository _alunoRepository { get; set; }

        public AlunoService()
        {
            _alunoRepository = new AlunoRepository();
        }

        public void Menu()
        {
            Console.Title = "Menu Aluno";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao menu de Aluno\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - Buscar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Deletar");
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
                    Menu();
                    break;
            }
        }

        public void Buscar()
        {
            var todosAlunosSalvos = _alunoRepository.GetAll();
            foreach(var aluno in todosAlunosSalvos)
            {
                Console.WriteLine($"Nome: {aluno.Nome}\nIdade: {aluno.Idade}\n");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            Console.Write("Digite o nome: ");
            var nome = Console.ReadLine();

            Console.Write("Digite a idade: ");
            var idade = Convert.ToInt32(Console.ReadLine());

            //var todasAsTurmas = _turmaRepository.GetAll();
            //Mostrar todas as turmas

            var aluno = new Entidades.Aluno(nome, idade);

            _alunoRepository.Criar(aluno);
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var alunoSalvo = _alunoRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {alunoSalvo.Nome}\nIdade: {alunoSalvo.Idade} ****\n");

            Console.WriteLine("\nDigite o novo nome: ");
            var novoNome = Console.ReadLine();

            Console.WriteLine("\nDigite a nova idade: ");
            var novaIdade = Convert.ToInt32(Console.ReadLine());

            alunoSalvo.Atualizar(novoNome, novaIdade);

            _alunoRepository.Atualizar(alunoSalvo);
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var alunoSalvo = _alunoRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {alunoSalvo.Nome}\nIdade: {alunoSalvo.Idade} ****\n");

            _alunoRepository.Deletar(alunoSalvo);
        }
    }
}
