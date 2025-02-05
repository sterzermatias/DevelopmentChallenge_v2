using System;
using DevelopmentChallenge.Data.Models;

namespace DevelopmentChallenge.Data.Services
{
    public class Validador
    {
        public void ValidarCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que 0.");
        }

        public void ValidarIdioma(string codigoIdioma)
        {
            if (!Idioma.ExisteIdioma(codigoIdioma))
                throw new ArgumentException("Idioma no soportado.");
        }
    }
}
