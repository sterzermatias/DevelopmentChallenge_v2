using System;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Utils;

namespace DevelopmentChallenge.Data.Services
{
    public class Validador
    {
        public void ValidarCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException(ConstantesAplicacion.ErrorCantidadInvalida);
        }

        public void ValidarIdioma(string codigoIdioma)
        {
            if (!Idioma.ExisteIdioma(codigoIdioma))
                throw new ArgumentException(ConstantesAplicacion.ErrorIdiomaNoSoportado);
        }
    }
}
