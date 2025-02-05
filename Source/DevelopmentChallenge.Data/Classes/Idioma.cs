using System.Collections.Generic;
using DevelopmentChallenge.Data.Utils;

namespace DevelopmentChallenge.Data.Classes
{
    public static class Idioma
    {
        private static readonly Dictionary<string, string> Idiomas = new Dictionary<string, string>
        {
            { ConstantesAplicacion.IdiomaEs, ConstantesAplicacion.NombreIdiomaEs },
            { ConstantesAplicacion.IdiomaEn, ConstantesAplicacion.NombreIdiomaEn },
            { ConstantesAplicacion.IdiomaIt, ConstantesAplicacion.NombreIdiomaIt }
        };

        public static bool ExisteIdioma(string codigo)
        {
            return Idiomas.ContainsKey(codigo);
        }
    }
}
