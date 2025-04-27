using System;
using System.Collections.Generic;

namespace JogoDaForca.ConsoleApp
{
    public class Jogo
    {
        public Categoria categorias = new Categoria();
        public EntradaUsuario entrada = new EntradaUsuario();

        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                MostrarCabecalho();

                string categoriaEscolhida = entrada.ObterCategoria();
                string[] palavras = ObterPalavras(categoriaEscolhida);

                if (palavras == null)
                {
                    Console.WriteLine("Categoria inválida! Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue;
                }

                JogarPartida(palavras, categoriaEscolhida);

                if (!entrada.DesejaContinuar())
                    break;
            }
        }

        public string[] ObterPalavras(string categoria)
        {
            switch (categoria)
            {
                case "FRUTAS": return categorias.frutas;
                case "ANIMAIS": return categorias.animais;
                case "PAÍSES":
                case "PAISES": return categorias.paises;
                default: return null;
            }
        }

        public void MostrarCabecalho()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("***************** JOGO DA FORCA ******************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Escolha uma categoria: Frutas, Animais ou Países ");
        }

        public void JogarPartida(string[] palavras, string categoriaEscolhida)
        {
            Random random = new Random();
            string palavraEscolhida = palavras[random.Next(palavras.Length)];

            char[] letrasEncontradas = new char[palavraEscolhida.Length];
            for (int i = 0; i < letrasEncontradas.Length; i++)
                letrasEncontradas[i] = '_';

            List<char> letrasChutadas = new List<char>();
            int quantidadeErros = 0;
            bool jogadorAcertou = false;
            bool jogadorEnforcou = false;

            do
            {
                DesenhoForca(quantidadeErros, categoriaEscolhida, letrasChutadas, letrasEncontradas);

                string tentativa = entrada.ObterTentativa();

                if (tentativa.Length > 1)
                {
                    jogadorAcertou = tentativa == palavraEscolhida;
                    if (!jogadorAcertou) quantidadeErros++;
                }
                else
                {
                    ProcessarLetra(tentativa[0], palavraEscolhida, letrasChutadas, letrasEncontradas, ref quantidadeErros);
                    jogadorAcertou = new string(letrasEncontradas) == palavraEscolhida;
                }

                jogadorEnforcou = quantidadeErros > 5;
            } while (!jogadorAcertou && !jogadorEnforcou);

            MostrarResultado(jogadorAcertou, palavraEscolhida);
        }

        private void DesenhoForca(int erros, string categoria, List<char> chutes, char[] letras)
        {
            string cabeca = erros >= 1 ? " o " : " ";
            string tronco = erros >= 2 ? "x" : " ";
            string troncoBaixo = erros >= 2 ? " x " : " ";
            string bracoEsquerdo = erros >= 3 ? "/" : " ";
            string bracoDireito = erros >= 4 ? "\\" : " ";
            string pernas = erros >= 5 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabeca);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Categoria escolhida: " + categoria);
            Console.WriteLine("Erros do jogador: " + erros);
            Console.WriteLine("Letras já chutadas: " + string.Join(", ", chutes));
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Palavra escolhida: " + new string(letras));
            Console.WriteLine("----------------------------------------------");
        }

        private void ProcessarLetra(char chute, string palavra, List<char> chutes, char[] letras, ref int erros)
        {
            if (chutes.Contains(chute))
            {
                Console.WriteLine("Você já chutou essa letra. Pressione Enter para continuar.");
                Console.ReadLine();
                return;
            }

            chutes.Add(chute);
            bool acertou = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == chute)
                {
                    letras[i] = chute;
                    acertou = true;
                }
            }

            if (!acertou) erros++;
        }

        public void MostrarResultado(bool venceu, string palavra)
        {
            Console.Clear();
            if (venceu)
                Console.WriteLine("Parabéns! Você acertou a palavra " + palavra);
            else
                Console.WriteLine("Você perdeu! A palavra era " + palavra);
        }
    }
}