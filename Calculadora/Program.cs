using System;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    internal class Program
    {
        struct NumeroComNome
        {
            public int Numero;
            public string Nome;
        }

        static void Main(string[] args)
        {
            ExecutarCalculadora(); // Aqui só chamamos o método
        }

        public static void ExecutarCalculadora()
        {
            bool repetir = true;

            while (repetir)
            {
                NumeroComNome[] itens = new NumeroComNome[4];
                itens[0] = new NumeroComNome { Numero = 1, Nome = "Adição" };
                itens[1] = new NumeroComNome { Numero = 2, Nome = "Subtração" };
                itens[2] = new NumeroComNome { Numero = 3, Nome = "Multiplicação" };
                itens[3] = new NumeroComNome { Numero = 4, Nome = "Divisão" };

                int escolha;
                bool encontrou = false;

                // Tela
                do
                {
                    Console.Clear();
                    Console.WriteLine("Calculadora:");
                    Console.WriteLine("Digite de 1 a 4 qual a operação matemática deseja fazer:");
                    Console.WriteLine("1 - Adição");
                    Console.WriteLine("2 - Subtração");
                    Console.WriteLine("3 - Multiplicação");
                    Console.WriteLine("4 - Divisão");
                    Console.Write("Digite o número da operação: ");

                    bool sucesso = int.TryParse(Console.ReadLine(), out escolha);

                    if (!sucesso)
                    {
                        Console.WriteLine("Entrada inválida. Pressione Enter para tentar novamente...");
                        Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < itens.Length; i++)
                    {
                        if (escolha == itens[i].Numero)
                        {
                            encontrou = true;
                            Console.Clear();
                            Console.WriteLine("Você escolheu: " + itens[i].Nome);
                            break;
                        }
                    }

                    if (!encontrou)
                    {
                        Console.WriteLine("Operação inválida. Pressione Enter para tentar novamente...");
                        Console.ReadLine();
                    }

                } while (!encontrou);

                // Parte do cálculo
                double numero1, numero2, resultado = 0;

                Console.WriteLine("Digite o Primeiro Número:");
                numero1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite o Segundo Número:");
                numero2 = Convert.ToDouble(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        resultado = Adicao(numero1, numero2);
                        break;
                    case 2:
                        resultado = Subtracao(numero1, numero2);
                        break;
                    case 3:
                        resultado = Multiplicacao(numero1, numero2);
                        break;
                    case 4:
                        resultado = Divisao(numero1, numero2);
                        break;
                    default:
                        Console.WriteLine("Erro.");
                        return;
                }

                Console.WriteLine("O resultado da operação com os números {0} e {1} é: {2}", numero1, numero2, resultado);
                Console.WriteLine();
                Console.WriteLine("Deseja fazer outra operação matemática?");
                Console.WriteLine("1 - Sim ou 2 - Não");
                Console.WriteLine(); // só pra pular linha

                char opcao = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (opcao == '1')
                {
                    repetir = true;
                    Console.WriteLine("Vamos fazer outra operação!");
                    Console.WriteLine("Pressione Enter para continuar...");
                    Console.ReadLine();
                }
                else if (opcao == '2')
                {
                    Console.WriteLine("Encerrando... Pressione Enter para sair.");
                    Console.ReadLine();
                    Environment.Exit(0);
                    repetir = false; // sai do laço
                }
                else
                {
                    Console.WriteLine("Opção inválida! Pressione Enter e tente novamente.");
                    Console.ReadLine();
                    repetir = true; // repete o laço
                }
            }
        }

        public static double Adicao(double numero1, double numero2)
        {
            return numero1 + numero2;
        }

        public static double Subtracao(double numero1, double numero2)
        {
            return numero1 - numero2;
        }

        public static double Multiplicacao(double numero1, double numero2)
        {
            return numero1 * numero2;
        }

        public static double Divisao(double numero1, double numero2)
        {
            if (numero2 == 0)
            {
                Console.WriteLine("Não é possível dividir por zero.");
                return 0;
            }
            return numero1 / numero2;
        }
    }
}
