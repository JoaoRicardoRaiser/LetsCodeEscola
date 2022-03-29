using LestsCodeEscola.Estudante.Repository;
using LestsCodeEscola.Nota.Repository;
using LestsCodeEscola.Professor.Repository;
using System;
using System.Linq;
using System.Threading;

namespace LestsCodeEscola.Nota.Services
{
    public class NotaService
    {
        private NotaRepository _notaRepository { get; set; }
        private AlunoRepository _alunoRepository { get; set; }
        private ProfessorRepository _professorRepository { get; set; }

        public NotaService()
        {
            _notaRepository = new NotaRepository();
            _alunoRepository = new AlunoRepository();
            _professorRepository = new ProfessorRepository();
        }

        public void Menu()
        {
            Console.Title = "Menu Notas";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao menu de Notas\n");
            while (true)
            {
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
                        this.Menu();
                        break;
                }
            }
        }


        public void Buscar()
        {
            Console.Clear();

            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var aluno = _alunoRepository.ObterPorCpf(cpf);

            foreach (var nota in aluno.Notas)
            {
                Console.WriteLine($"Disciplina: {nota.Disciplina}\nNota: {nota.ValorNota}\n");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();

            Console.Write("Professor, digite o seu CPF (sem . e -): ");
            var cpfProfessor = Console.ReadLine();
            var professor = _professorRepository.ObterPorCpf(cpfProfessor);

            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpfAluno = Console.ReadLine();
            var aluno = _alunoRepository.ObterPorCpf(cpfAluno);

            Console.Write("Digite a Disciplina: ");
            var disciplina = Console.ReadLine();

            Console.Write("Digite a nota: ");
            var valorNota = double.Parse(Console.ReadLine());

            var notaCadastrada = new Entidades.Nota(valorNota, aluno.Id, professor.Id, disciplina);
            
            _alunoRepository.AdicionarNotaParaAluno(aluno, notaCadastrada);
            _notaRepository.Criar(notaCadastrada);
        }

        public void Editar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var aluno = _alunoRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {aluno.Nome} ****\n");
            foreach(var nota in aluno.Notas)
            {
                Console.WriteLine($"**** Nota: {nota.ValorNota}\nDisciplina: {nota.Disciplina} ****\n");
                Console.WriteLine("Gostaria de alterar esta nota? S/N");
                var resposta = Console.ReadLine();
                if (resposta.ToUpper() == "S")
                {
                    Console.Write("Insira o valor da nota: ");
                    var novaNota = double.Parse(Console.ReadLine());
                    nota.ValorNota = novaNota;
                    _alunoRepository.Atualizar(aluno);
                }
            }
        }

        public void Deletar()
        {
            Console.Clear();
            Console.Write("Digite o CPF do aluno (sem . e -): ");
            var cpf = Console.ReadLine();

            var aluno = _alunoRepository.ObterPorCpf(cpf);

            Console.WriteLine("\nAluno encontrado\n");
            Console.WriteLine($"**** Nome: {aluno.Nome} ****\n");
            foreach (var nota in aluno.Notas.ToList())
            {
                Console.WriteLine($"**** Nota: {nota.ValorNota}\nDisciplina: {nota.Disciplina} ****\n");
                Console.WriteLine("Gostaria de excluir esta nota? S/N");
                var resposta = Console.ReadLine();
                if (resposta.ToUpper() == "S")
                {
                    aluno.Notas.Remove(nota);
                    _alunoRepository.Atualizar(aluno);
                    _notaRepository.Deletar(nota);
                }
            }
        }
    }
}
