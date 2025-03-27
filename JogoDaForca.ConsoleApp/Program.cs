﻿namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string palavraEscolhida = "MELANCIA";

            char[] letrasEncontradas = new char[palavraEscolhida.Length];

            for (int caractere = 0; caractere < letrasEncontradas.Length; caractere++)
                letrasEncontradas[caractere] = '_';

            int quantidadeErros = 0;
            bool jogadorEnforcou = false;
            bool jogadorAcertou = false;

            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Jogo da Forca");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Erros do jogador: " + quantidadeErros);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Palavra escolhida: " + String.Join("", letrasEncontradas));
                Console.WriteLine("----------------------------------------------");

                Console.Write("Digite uma letra: ");
                char chute = Console.ReadLine().ToUpper()[0];

                bool letraFoiEncontrada = false;

                for (int contador = 0; contador < palavraEscolhida.Length; contador++)
                {
                    char letraAtual = palavraEscolhida[contador];

                    if (chute == letraAtual)
                    {
                        letrasEncontradas[contador] = letraAtual;
                        letraFoiEncontrada = true;
                    }
                }

                if (letraFoiEncontrada == false)
                    quantidadeErros++;

                string palavraEncontrada = String.Join("", letrasEncontradas);

                jogadorAcertou = palavraEncontrada == palavraEscolhida;
                jogadorEnforcou = quantidadeErros > 5;

                if (jogadorAcertou)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Você acertou a palavra secreta {palavraEscolhida}, parabéns!");
                    Console.WriteLine("----------------------------------------------");
                }
                else if (jogadorEnforcou)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Que azar! Tente novamente!");
                    Console.WriteLine("----------------------------------------------");
                }
            } while (jogadorEnforcou == false && jogadorAcertou == false);

            Console.ReadLine();
        }
    }
}