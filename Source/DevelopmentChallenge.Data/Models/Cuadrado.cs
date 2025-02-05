using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Models
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;
        private readonly Validador _validador;

      
        private static readonly Dictionary<string, string[]> Traducciones = new Dictionary<string, string[]>
        {
            { ConstantesAplicacion.IdiomaEs, new string[] { ConstantesAplicacion.NombreCuadradoEs, ConstantesAplicacion.NombreCuadradosEs } },
            { ConstantesAplicacion.IdiomaEn, new string[] { ConstantesAplicacion.NombreCuadradoEn, ConstantesAplicacion.NombreCuadradosEn } },
            { ConstantesAplicacion.IdiomaIt, new string[] { ConstantesAplicacion.NombreCuadradoIt, ConstantesAplicacion.NombreCuadradosIt } }
        };
        public Cuadrado(decimal lado, Validador validador = null)
        {
            if (lado <= 0)
                throw new ArgumentException(ConstantesAplicacion.ErrorValorInvalido);
            _lado = lado;
            _validador = validador ?? new Validador();
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public string ObtenerNombre(int cantidad, string codigoIdioma)
        {
            _validador.ValidarCantidad(cantidad);

            _validador.ValidarIdioma(codigoIdioma);

            return cantidad == 1 ? Traducciones[codigoIdioma][0] : Traducciones[codigoIdioma][1];
        }
    }

}
