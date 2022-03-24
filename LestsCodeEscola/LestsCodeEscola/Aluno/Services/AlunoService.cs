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

            Menu();
        }

        public void Buscar()
        {
            var todosAlunosSalvos = _alunoRepository.GetAll();
            Console.Clear();
            Console.WriteLine("Alunos cadastrados:");
            foreach(var aluno in todosAlunosSalvos)
            {
                Console.WriteLine($"\nNome: {aluno.Nome}\nIdade: {aluno.Idade}\nCpf: {aluno.Cpf}");
            }

            Console.WriteLine("\nDigite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void Cadastrar()
        {
            try
            {
                Console.Clear();

                Console.Write("Digite o nome: ");
                var nome = Console.ReadLine();

                Console.Write("\nDigite a idade: ");
                var idade = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nDigite o CPF (sem . e -): ");
                var cpf = Console.ReadLine();

                //var todasAsTurmas = _turmaRepository.GetAll();
                //Mostrar todas as turmas

                var aluno = new Entidades.Aluno(nome, idade, cpf);

                _alunoRepository.Criar(aluno);

                Console.WriteLine("\nAluno cadastrado com sucesso!");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao cadastrar aluno: {e}\n");
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Editar()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o CPF do aluno (sem . e -): ");
                var cpf = Console.ReadLine();

                var alunoSalvo = _alunoRepository.ObterPorCpf(cpf);

                Console.WriteLine("\nAluno encontrado\n");
                Console.WriteLine($"**** \nNome: {alunoSalvo.Nome}\nIdade: {alunoSalvo.Idade}\n****\n");

                Console.WriteLine("\nDigite o novo nome: ");
                var novoNome = Console.ReadLine();
                if (novoNome == "")
                {
                    novoNome = alunoSalvo.Nome;
                }

                Console.WriteLine("\nDigite a nova idade: ");
                var novaIdade = Convert.ToInt32(Console.ReadLine());

                alunoSalvo.Atualizar(novoNome, novaIdade);

                _alunoRepository.Atualizar(alunoSalvo);

                Console.WriteLine("\nAluno editado com sucesso!");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao editar aluno: {e}\n");
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
            
        }

        public void Deletar()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o CPF do aluno (sem . e -): ");
                var cpf = Console.ReadLine();

                var alunoSalvo = _alunoRepository.ObterPorCpf(cpf);
                if (alunoSalvo == null)
                {
                    Console.WriteLine($"Aluno com cpf {cpf} não encontrado");
                    Thread.Sleep(2000);
                    return;
                }

                Console.WriteLine("\nAluno encontrado\n");
                Console.WriteLine($"**** Nome: {alunoSalvo.Nome}\nIdade: {alunoSalvo.Idade} ****\n");

                _alunoRepository.Deletar(alunoSalvo);

                Console.WriteLine($"\nAluno com CPF {alunoSalvo.Cpf} deletado com sucesso!");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao deletar aluno: {e}\n");
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
