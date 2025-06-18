using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Calculadora:");
            Console.WriteLine("Digite de 1 a 4 qual a operação matemática deseja fazer:");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");

            NumeroComNome[] itens = new NumeroComNome[4];

            itens[0] = new NumeroComNome { Numero = 1, Nome = "Adição" };
            itens[1] = new NumeroComNome { Numero = 2, Nome = "Subtração" };
            itens[2] = new NumeroComNome { Numero = 3, Nome = "Multiplicação" };
            itens[3] = new NumeroComNome { Numero = 4, Nome = "Divisão" };

            Console.Write("Digite o número da operação: ");
            int escolha = int.Parse(Console.ReadLine());

            bool encontrou = false;

            for (int i = 0; i < itens.Length; i++)
            {
                if (escolha == itens[i].Numero)
                {
                    Console.WriteLine("Você escolheu: " + itens[i].Nome);
                    encontrou = true;
                    break;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Operação inválida.");
                return;
            }

            // Parte do cálculo
            Console.WriteLine("Digite o Primeiro Número:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Segundo Número:");
            int num2 = int.Parse(Console.ReadLine());

            int resultado = 0;

            switch (escolha)
            {
                case 1:
                    resultado = Adicao(num1, num2);
                    break;
                case 2:
                    resultado = Subtracao(num1, num2);
                    break;
                case 3:
                    resultado = Multiplicacao(num1, num2);
                    break;
                case 4:
                    resultado = Divisao(num1, num2);
                    break;
                default:
                    Console.WriteLine("Número inválido, Digite outro número");
                    return;
            }

            Console.WriteLine("O resultado da operação com os números {0} e {1} é: {2}", num1, num2, resultado);
            Console.ReadLine();
        }

        public static int Adicao(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public static int Subtracao(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        public static int Multiplicacao(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        public static int Divisao(int numero1, int numero2)
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










