using LestsCodeEscola.Aula.Entidades;
using LestsCodeEscola.Aula.Repository;
using LestsCodeEscola.Comum;
using LestsCodeEscola.Estudante.Entidades;
using LestsCodeEscola.Estudante.Repository;
using System;
using System.Linq;
using System.Threading;

namespace LestsCodeEscola.Estudante.Services
{
    public class AlunoService
    {
        private AlunoRepository _alunoRepository { get; set; }
        private TurmaRepository _turmaRepository { get; set; }

        public AlunoService()
        {
            _alunoRepository = new AlunoRepository();
            _turmaRepository = new TurmaRepository();

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
            Utils.MostrarAlunos(todosAlunosSalvos);
            Console.WriteLine("\nDigite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void Cadastrar()
        {
            try
            {
                Console.Clear();

                var nome = ObterNome(OpcaoCrud.CADASTRO);
                var idade = ObterIdade();
                var cpf = ObterCpf();

                var turma = ObterTurma(OpcaoCrud.CADASTRO);

                var aluno = new Aluno(nome, idade, cpf, turma.Id);

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
                var alunoSalvo = ObterAlunoSalvo();

                Console.Clear();
                Utils.MostarAlunoEncontrado(alunoSalvo);

                var novoNome = ObterNome(OpcaoCrud.EDICAO);
                if (novoNome == "")
                {
                    novoNome = alunoSalvo.Nome;
                }

                var novaIdade = ObterIdade();

                var novaTurma = ObterTurma(OpcaoCrud.EDICAO);
                var turmaId = novaTurma == null ? alunoSalvo.TurmaId : novaTurma.Id;

                alunoSalvo.Atualizar(novoNome, novaIdade, turmaId);

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

                var alunoSalvo = ObterAlunoSalvo();
                
                Console.Clear();
                Utils.MostarAlunoEncontrado(alunoSalvo);
                Thread.Sleep(2000);

                _alunoRepository.Deletar(alunoSalvo);

                Console.WriteLine($"Aluno com CPF {alunoSalvo.Cpf} deletado com sucesso!");
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao deletar aluno: {e}\n");
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static string ObterNome(OpcaoCrud opcao)
        {
            bool solicitaNomeNovamente;
            string nome;
            do
            {
                if (opcao.Equals(OpcaoCrud.CADASTRO))
                    Console.Write("Digite o nome: ");
                else if (opcao.Equals(OpcaoCrud.EDICAO))
                    Console.Write("Digite o novo nome (deixe em branco para não alterar): ");
                
                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome) && opcao.Equals(OpcaoCrud.CADASTRO))
                {
                    Console.WriteLine("Nome inválido... Tente novamente.");
                    Thread.Sleep(2000);
                    solicitaNomeNovamente = true;
                    Console.Clear();
                }
                else
                {
                    solicitaNomeNovamente = false;
                }
            } 
            while (solicitaNomeNovamente);

            return nome;
        }

        private static int ObterIdade()
        {
            bool solicitaIdadeNovamente;
            int idade;
            bool ehNumero;
            do
            {
                Console.Write("\nDigite a idade: ");
                ehNumero = int.TryParse(Console.ReadLine(), out idade);
                if(!ehNumero || idade == 0)
                {
                    Console.WriteLine("\nIdade inválida... Tente novamente.");
                    Thread.Sleep(2000);
                    solicitaIdadeNovamente = true;
                    Console.Clear();
                }
                else
                {
                    solicitaIdadeNovamente = false;
                }
            }
            while (solicitaIdadeNovamente);

            return idade;
        }

        private static string ObterCpf()
        {
            bool solicitaCpfNovamente;
            string cpf;
            do
            {
                Console.Write("\nDigite o CPF (sem . e -): ");
                cpf = Console.ReadLine();

                if(cpf.Length != 11)
                {
                    Console.WriteLine("\nCPF inválido... Tente novamente.");
                    Thread.Sleep(2000);
                    solicitaCpfNovamente = true;
                    Console.Clear();
                }
                else
                {
                    solicitaCpfNovamente = false;
                }

            } while (solicitaCpfNovamente);

            return cpf;
        }

        private Aluno ObterAlunoSalvo()
        {
            bool deveBuscarNovamente;
            Aluno alunoSalvo;
            
            do
            {
                var cpf = ObterCpf();

                alunoSalvo = _alunoRepository.ObterPorCpf(cpf);

                if (alunoSalvo == null)
                {
                    Console.WriteLine($"Aluno com CPF: {cpf} não encontrado na base de dados\n Tente novamente...");
                    Thread.Sleep(2000);
                    deveBuscarNovamente = true;
                    Console.Clear();
                }
                else
                {
                    deveBuscarNovamente = false;
                }
            } while (deveBuscarNovamente);

            return alunoSalvo;
        }

        private Turma ObterTurma(OpcaoCrud opcao)
        {
            bool deveBuscarNovamente;
            Turma turmaSelecionada;
            var todasAsTurmas = _turmaRepository.GetAll();
            do
            {
                Console.Clear();
                Console.WriteLine("Turmas Cadastradas: \n");
                Utils.MostrarTurmas(todasAsTurmas);

                if (opcao.Equals(OpcaoCrud.CADASTRO))
                    Console.Write("Digite o nome da turma: ");
                else if (opcao.Equals(OpcaoCrud.EDICAO))
                    Console.Write("Digite o novo nome da turma (deixe em branco para não alterar): ");

                var nomeTurma = Console.ReadLine();
                turmaSelecionada = todasAsTurmas.SingleOrDefault(x => x.NomeTurma == nomeTurma);
                
                if (turmaSelecionada == null && opcao.Equals(OpcaoCrud.CADASTRO))
                {
                    Console.WriteLine("\nNome da turma digitada não existe... Tente novamente");
                    deveBuscarNovamente = true;
                }
                else
                {
                    deveBuscarNovamente = false;
                }

            } while (deveBuscarNovamente);

            return turmaSelecionada;
        }
    }
}
