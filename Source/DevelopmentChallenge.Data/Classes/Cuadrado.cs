/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
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
                throw new ArgumentException("El lado debe ser mayor que 0.");
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
