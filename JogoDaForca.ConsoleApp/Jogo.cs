using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.ConsoleApp
{
    public class Jogo
    {
        public Categoria categorias = new Categoria();
        public EntradaUsuario entrada = new EntradaUsuario();

        public void Iniciar()
        {
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
        }
    }
}