using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;
        private readonly Validador _validador;


        private static readonly Dictionary<string, string[]> Traducciones = new Dictionary<string, string[]>
        {
            { ConstantesAplicacion.IdiomaEs, new string[] { ConstantesAplicacion.NombreTrianguloEs, ConstantesAplicacion.NombreTriangulosEs } },
            { ConstantesAplicacion.IdiomaEn, new string[] { ConstantesAplicacion.NombreTrianguloEn, ConstantesAplicacion.NombreTriangulosEn } },
            { ConstantesAplicacion.IdiomaIt, new string[] { ConstantesAplicacion.NombreTrianguloIt, ConstantesAplicacion.NombreTriangulosIt } }
        };
        public TrianguloEquilatero(decimal lado, Validador validador = null)
        {
            if (lado <= 0)
                throw new ArgumentException("El lado debe ser mayor que 0.");
            _lado = lado;
            _validador = validador ?? new Validador(); 
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public string ObtenerNombre(int cantidad, string codigoIdioma)
        {
            _validador.ValidarCantidad(cantidad);

            _validador.ValidarIdioma(codigoIdioma);

            return cantidad == 1 ? Traducciones[codigoIdioma][0] : Traducciones[codigoIdioma][1];
        }
    }
}
