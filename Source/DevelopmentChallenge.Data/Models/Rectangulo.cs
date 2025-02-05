using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Models
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal _base;
        private readonly decimal _altura;
        private readonly Validador _validador;


        private static readonly Dictionary<string, string[]> Traducciones = new Dictionary<string, string[]>
        {
            { ConstantesAplicacion.IdiomaEs, new string[] { ConstantesAplicacion.NombreRectanguloEs, ConstantesAplicacion.NombreRectangulosEs } },
            { ConstantesAplicacion.IdiomaEn, new string[] { ConstantesAplicacion.NombreRectanguloEn, ConstantesAplicacion.NombreRectangulosEn } },
            { ConstantesAplicacion.IdiomaIt, new string[] { ConstantesAplicacion.NombreRectanguloIt, ConstantesAplicacion.NombreRectangulosIt } }
        };
        public Rectangulo(decimal baseRectangulo, decimal altura, Validador validador = null)
        {
            if (baseRectangulo <= 0 || altura <= 0)
                throw new ArgumentException(ConstantesAplicacion.ErrorValorInvalido);

            _base = baseRectangulo;
            _altura = altura;
            _validador = validador ?? new Validador();
        }

        public decimal CalcularArea()
        {
            return _base * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }

        public string ObtenerNombre(int cantidad, string codigoIdioma)
        {
            _validador.ValidarCantidad(cantidad);

            _validador.ValidarIdioma(codigoIdioma);

            return cantidad == 1 ? Traducciones[codigoIdioma][0] : Traducciones[codigoIdioma][1];
        }
    }
}
