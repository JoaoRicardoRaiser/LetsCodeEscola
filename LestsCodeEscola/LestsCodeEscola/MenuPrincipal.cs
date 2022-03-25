using LestsCodeEscola.Aluno.Services;
using LestsCodeEscola.Aula.Services;
using LestsCodeEscola.Nota.Services;
using LestsCodeEscola.Professor.Services;
using System;
using System.Threading;

namespace LestsCodeEscola
{
    public static class MenuPrincipal
    {
        public static void Iniciar()
        {
            var alunoService = new AlunoService();
            var aulaService = new AulaService();
            var professorService = new ProfessorService();
            var notaService = new NotaService();

            Console.Title = "Lets Code Escola";
            Console.Clear();
            Console.WriteLine("Seja bem vindo à LetsCode Escola\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - Menu Aluno");
            Console.WriteLine("2 - Menu Professor");
            Console.WriteLine("3 - Menu Turma");
            Console.WriteLine("4 - Menu Aula");
            Console.WriteLine("5 - Menu Nota");
            Console.WriteLine("0 - Sair\n");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    alunoService.Menu();
                    break;

                case "2":
                    professorService.Menu();
                    break;

                case "3":
                    //salaService.Menu();
                    break;

                case "4":
                    aulaService.Menu();
                    break;

                case "5":
                    notaService.Menu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nOpção invalida, tente novamente...\n");
                    Thread.Sleep(2000);
                    Iniciar();
                    break;
            }
        }
    }
}
