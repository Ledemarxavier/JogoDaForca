using System;
using System.Collections.Generic;

namespace JogoDaForca.ConsoleApp
{
    public class EntradaUsuario
    {
        public string ObterCategoria()
        {
            return Console.ReadLine().ToUpper();
        }

        public string ObterTentativa()
        {
            return Console.ReadLine().ToUpper();
        }

        public bool DesejaContinuar()
        {
            Console.Write("Jogar novamente? (S/N): ");
            return Console.ReadLine().ToUpper() == "S";
        }
    }
}