using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
namespace ProjetoTP1
{
    class Program
    {
        static public ConsoleKeyInfo shouldistay;
        
        static void Main(string[] args)
        {
            BackgroundColor = ConsoleColor.White;
            Clear();
            MenuDeOpcoes();
        }
        static void MenuDeOpcoes()
        {
            ConsoleKeyInfo OpcaoDesejada = new ConsoleKeyInfo();
            do
            {
                ForegroundColor = ConsoleColor.Black;
                Escritor("Rafael Pak - 18206 || Henrique Esteban - 18191", 10, 1);
                
                Escritor("Operações", 2, 3);
                Escritor("=-=-=-=-=", 2, 4);
                ForegroundColor = ConsoleColor.Red;
                Escritor("a - Números amigos", 2, 6);
                ForegroundColor = ConsoleColor.Blue;
                Escritor("b - Decimal para binário", 2, 7);
                ForegroundColor = ConsoleColor.DarkYellow;
                Escritor("c - Fibonacci e Proporção Áurea", 2, 8);
                ForegroundColor = ConsoleColor.Green;
                Escritor("d - Constante de Catalan", 2, 9);
                ForegroundColor = ConsoleColor.Magenta;
                Escritor("e - Constante de Primos Gêmeos", 2, 10);
                ForegroundColor = ConsoleColor.DarkBlue;
                Escritor("f - Processamento de Dados em Arquivo Texto", 2, 11);
                ForegroundColor = ConsoleColor.Cyan;
                Escritor("6 - Terminar o programa", 2, 12);
                ForegroundColor = ConsoleColor.Black;
                Escritor("Digite o valor da operação desejada: ", 2, 14);
                OpcaoDesejada = ReadKey();

                while (OpcaoDesejada.KeyChar != 'a' && OpcaoDesejada.KeyChar != 'b' && OpcaoDesejada.KeyChar != 'c' && OpcaoDesejada.KeyChar != 'd' && OpcaoDesejada.KeyChar != 'e' && OpcaoDesejada.KeyChar != 'f' && OpcaoDesejada.KeyChar != '6') ;
                switch (OpcaoDesejada.KeyChar)
                {
                    case 'a':
                        NumerosAmigos();
                        break;

                    case 'b':
                        DecimalBinario();
                        break;

                    case 'c':
                        FibonacciAurea();
                        break;

                    case 'd':
                        Catalan();
                        break;

                    case 'e':
                        ConstPrimosGemeos();
                        break;

                    case 'f':
                        Ler();
                        break;

                    case '6': break;
                }
            }
            while (OpcaoDesejada.KeyChar != '6');
        }

        static void NumerosAmigos()
        {
            int Bango;
            bool num;
            do
            {
                do
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    Escritor("Digite até qual número deseja que se procure por números amigos: ", 1, 3);
                    num = int.TryParse(ReadLine(), out Bango);
                }
                while (num == false);
                var mat = new Matematica(Bango);
                List<string> amigos = mat.Amigos();
                foreach (string par in amigos)
                {
                    WriteLine(par);
                }
                Esperar();
                Clear();
            }
            while (shouldistay.Key != ConsoleKey.Escape);
        }
    
        static void DecimalBinario()
        {
            int Bango;
            bool num;
            do
            {
                do
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    Escritor("Escreva um número inteiro, positivo, menor que 64, para binário: ", 1, 3); 
                    num = int.TryParse(ReadLine(), out Bango);
                }
                while (num == false || Bango > 64 || Bango < 0);
                var mat = new Matematica(Bango);
                Escritor(mat.ParaBinario() + "", 5, 5);
                Esperar();
                Clear();
            }
            while (shouldistay.Key != ConsoleKey.Escape);
        }

        static void FibonacciAurea()
        {
            int Bango;
            bool num;
            do
            {
                do
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Escritor("Digite a quantidade de termos da sequência Fibonacci que deseja encontrar: ", 1, 3);
                    num = int.TryParse(ReadLine(), out Bango);
                }
                while (num == false);
                var mat = new Matematica(Bango);
                List<int> sequenciaFibonacci = mat.Fibonacci();
                Write("\n\t");
                foreach (int termo in sequenciaFibonacci)
                {
                    Write($"{termo} ");
                }
                Esperar();
                Clear();
            }
            while (shouldistay.Key != ConsoleKey.Escape);
        }

        static void Catalan()
        {
            int Bango;
            bool num;
            do
            {
                do
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Green;
                    Escritor("Escreva quantos termos a constante de Catalan deverá ter: ", 1, 3);
                    num = int.TryParse(ReadLine(), out Bango);
                }
                while (num == false);
                var catalan = new Matematica(Bango);
                Escritor($"{catalan.Catalan()}", 6, 5);
                Esperar();
                Clear();
            }
            while (shouldistay.Key != ConsoleKey.Escape);
        }

        static void ConstPrimosGemeos()
        {
            int Bango;
            bool certo;
            do
            {
                do
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Magenta;
                    Escritor("Digite até qual número os primos serão processados: ", 6, 3);                  
                    certo = int.TryParse(ReadLine(), out Bango);
                }
                while (certo == false);
                var constantePrimos = new Matematica(Bango);
                Escritor($"{constantePrimos.ConstanteDePrimosGemeos()}", 6, 5);
                Esperar();
                Clear();
            }
            while (shouldistay.Key != ConsoleKey.Escape);
        }

        public static void Ler()
        {
            Clear();
            string classe, RA;
            double nota;
            var leitor = new StreamReader(@"C:\temp\dados.txt");
            while (!leitor.EndOfStream)
            {
                var Aluno = new Aluno();
                Aluno.Informacoes(leitor);
                Escritor($"Classe: ${Aluno.Classe}", 2, 5);
                Escritor($"RA: ${Aluno.ra}", 2, 6);
                Escritor($"Nota: ${Aluno.Nota}", 2, 7);

                int numeroDeNotas = 1;
                double somaDasNotas = 0.0, mediaDasNotas;
                numeroDeNotas++;
                somaDasNotas += Aluno.Nota;
                mediaDasNotas = somaDasNotas / numeroDeNotas;
                Escritor($"Média das notas da sala: {mediaDasNotas}", 2, 9);
            }
            leitor.Close();
            Esperar();
        }

        static void Escritor(string a, int x, int y)
        {
            SetCursorPosition(x, y);
            Write(a);
        }

        static void Esperar()
        {
            Escritor("Pressione ENTER para realizar uma nova ação. Pressione ESC para sair.", 1, 23);
            shouldistay = ReadKey();
        }
    }
}