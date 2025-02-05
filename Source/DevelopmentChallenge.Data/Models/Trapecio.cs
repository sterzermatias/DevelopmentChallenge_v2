using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Models
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        private readonly Validador _validador;

        private static readonly Dictionary<string, string[]> Traducciones = new Dictionary<string, string[]>
        {
            { ConstantesAplicacion.IdiomaEs, new string[] { ConstantesAplicacion.NombreTrapecioEs, ConstantesAplicacion.NombreTrapeciosEs } },
            { ConstantesAplicacion.IdiomaEn, new string[] { ConstantesAplicacion.NombreTrapecioEn, ConstantesAplicacion.NombreTrapeciosEn } },
            { ConstantesAplicacion.IdiomaIt, new string[] { ConstantesAplicacion.NombreTrapecioIt, ConstantesAplicacion.NombreTrapeciosIt } }
        };

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2, Validador validador = null)
        {
            if (baseMayor <= 0 || baseMenor <= 0 || altura <= 0 || lado1 <= 0 || lado2 <= 0)
                throw new ArgumentException(ConstantesAplicacion.ErrorValorInvalido);

            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
            _validador = validador ?? new Validador();
        }

        public decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _lado1 + _lado2;
        }

        public string ObtenerNombre(int cantidad, string codigoIdioma)
        {
            _validador.ValidarCantidad(cantidad);

            _validador.ValidarIdioma(codigoIdioma);

            return cantidad == 1 ? Traducciones[codigoIdioma][0] : Traducciones[codigoIdioma][1];
        }
    }
}
