using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class Program
{
    private static void Main()
    {
        // Arrays de categorias e palavras
        string[] frutas = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "BANANA", "CAJU", "CARAMBOLA", "GRAVIOLA", "GOIABA", "JABUTICABA", "MAÇA", "MANGA", "MARACUJA", "PEQUI", "PITANGA", "PITAYA", "TANGERINA", "UVA" };
        string[] animais = { "CACHORRO", "GATO", "ELEFANTE", "TIGRE", "LEAO", "BALEIA", "CAVALO", "GALINHA", "COELHO", "RATO", "URSO", "PANDA", "PAPAGAIO", "HIPOPOTAMO", "GIRRAFA", "JACARE", "CANGURU", "BUFALO", "TARTARUGA" };
        string[] paises = { "BRASIL", "ARGENTINA", "CANADA", "PORTUGAL", "JAPAO", "PANAMA", "PAQUISTAO", "PERU", "ISRAEL", "ALEMANHA", "ITALIA", "RUSSIA", "INDIA", "MARROCOS", "HAITI", "LIBANO", "MEXICO", "MOLDAVIA" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine("***************** JOGO DA FORCA ******************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Escolha uma categoria: Frutas, Animais ou Países ");
            string categoriaEscolhida = Console.ReadLine().ToUpper();

            string[] palavras;

            // Verifica a categoria escolhida
            switch (categoriaEscolhida)
            {
                case "FRUTAS":
                    palavras = frutas;
                    break;

                case "ANIMAIS":
                    palavras = animais;
                    break;

                case "PAÍSES":
                case "PAISES": // Permite escrita com ou sem acento
                    palavras = paises;
                    break;

                default:
                    Console.WriteLine("Categoria inválida! Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    continue; // Volta ao início do loop
            }

            // Sorteia uma palavra da categoria escolhida
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
                // Desenho da forca
                string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
                string tronco = quantidadeErros >= 2 ? "x" : " ";
                string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
                string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
                string bracoDireito = quantidadeErros >= 4 ? "\\" : " ";
                string pernas = quantidadeErros >= 5 ? "/ \\" : " ";

                Console.Clear();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Jogo da Forca");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(" ___________        ");
                Console.WriteLine(" |/        |        ");
                Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
                Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
                Console.WriteLine(" |        {0}       ", troncoBaixo);
                Console.WriteLine(" |        {0}       ", pernas);
                Console.WriteLine(" |                  ");
                Console.WriteLine(" |                  ");
                Console.WriteLine("_|____              ");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Categoria escolhida: " + categoriaEscolhida);
                Console.WriteLine("Erros do jogador: " + quantidadeErros);
                Console.WriteLine("Letras já chutadas: " + string.Join(", ", letrasChutadas));
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Palavra escolhida: " + new string(letrasEncontradas));
                Console.WriteLine("----------------------------------------------");

                Console.Write("Digite uma letra ou tente adivinhar a palavra inteira: ");
                string tentativa = Console.ReadLine().ToUpper();

                if (tentativa.Length > 1)
                {
                    if (tentativa == palavraEscolhida)
                    {
                        jogadorAcertou = true;
                        break;
                    }
                    else
                    {
                        quantidadeErros++;
                    }
                }
                else
                {
                    char chute = tentativa[0];
                    if (letrasChutadas.Contains(chute))
                    {
                        Console.WriteLine("Você já chutou essa letra. Pressione Enter para continuar.");
                        Console.ReadLine();
                        continue;
                    }

                    letrasChutadas.Add(chute);
                    bool letraFoiEncontrada = false;
                    for (int i = 0; i < palavraEscolhida.Length; i++)
                    {
                        if (palavraEscolhida[i] == chute)
                        {
                            letrasEncontradas[i] = chute;
                            letraFoiEncontrada = true;
                        }
                    }
                    if (!letraFoiEncontrada)
                        quantidadeErros++;
                }

                if (new string(letrasEncontradas) == palavraEscolhida)
                    jogadorAcertou = true;
                jogadorEnforcou = quantidadeErros > 5;
            } while (!jogadorAcertou && !jogadorEnforcou);

            Console.Clear();
            if (jogadorAcertou)
                Console.WriteLine("Parabéns! Você acertou a palavra " + palavraEscolhida);
            else
                Console.WriteLine("Você perdeu! A palavra era " + palavraEscolhida);

            Console.Write("Jogar novamente? (S/N): ");
            if (Console.ReadLine().ToUpper() != "S")
                break;
        }
    }
}