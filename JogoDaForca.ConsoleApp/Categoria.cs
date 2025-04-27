using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.ConsoleApp
{
    public class Categoria
    {
        public string[] frutas { get; } = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "BANANA", "CAJU", "CARAMBOLA", "GRAVIOLA", "GOIABA", "JABUTICABA", "MAÇA", "MANGA", "MARACUJA", "PEQUI", "PITANGA", "PITAYA", "TANGERINA", "UVA" };
        public string[] animais { get; } = { "CACHORRO", "GATO", "ELEFANTE", "TIGRE", "LEAO", "BALEIA", "CAVALO", "GALINHA", "COELHO", "RATO", "URSO", "PANDA", "PAPAGAIO", "HIPOPOTAMO", "GIRRAFA", "JACARE", "CANGURU", "BUFALO", "TARTARUGA" };
        public string[] paises { get; } = { "BRASIL", "ARGENTINA", "CANADA", "PORTUGAL", "JAPAO", "PANAMA", "PAQUISTAO", "PERU", "ISRAEL", "ALEMANHA", "ITALIA", "RUSSIA", "INDIA", "MARROCOS", "HAITI", "LIBANO", "MEXICO", "MOLDAVIA" };
    }
}