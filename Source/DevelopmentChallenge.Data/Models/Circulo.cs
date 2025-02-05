using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Models
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _radio;
        private readonly Validador _validador;


        private static readonly Dictionary<string, string[]> Traducciones = new Dictionary<string, string[]>
        {
            { ConstantesAplicacion.IdiomaEs, new string[] { ConstantesAplicacion.NombreCirculoEs, ConstantesAplicacion.NombreCirculosEs } },
            { ConstantesAplicacion.IdiomaEn, new string[] { ConstantesAplicacion.NombreCirculoEn, ConstantesAplicacion.NombreCirculosEn } },
            { ConstantesAplicacion.IdiomaIt, new string[] { ConstantesAplicacion.NombreCirculoIt, ConstantesAplicacion.NombreCirculosIt } }
        };

        public Circulo(decimal radio, Validador validador = null)
        {
            if (radio <= 0)
                throw new ArgumentException(ConstantesAplicacion.ErrorValorInvalido);
            _radio = radio;
            _validador = validador ?? new Validador();
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio * _radio);
        }

        public decimal CalcularPerimetro()
        {
            return 2 * (decimal)Math.PI * _radio;
        }

        public string ObtenerNombre(int cantidad, string codigoIdioma)
        {

            _validador.ValidarCantidad(cantidad);

            _validador.ValidarIdioma(codigoIdioma);

            return cantidad == 1 ? Traducciones[codigoIdioma][0] : Traducciones[codigoIdioma][1];
        }
    }
}
