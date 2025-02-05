using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
    public class GeneradorReporte
    {
        private readonly Validador _validador;

        public GeneradorReporte(Validador validador)
        {
            _validador = validador ?? throw new ArgumentNullException(nameof(validador));
        }


    private static string FormatearNumero(decimal numero, string codigoIdioma)
        {
            var cultura = codigoIdioma == ConstantesAplicacion.IdiomaEn ? CultureInfo.InvariantCulture : new CultureInfo("es-ES");
            return numero.ToString("#,##0.##", cultura);
        }

    public string Imprimir(List<IFormaGeometrica> formas, string codigoIdioma)
    {
        _validador.ValidarIdioma(codigoIdioma);

        if (!formas.Any())
            return $"<h1>{ObtenerMensajeListaVacia(codigoIdioma)}</h1>";

        var sb = new StringBuilder();
        sb.Append($"<h1>{ObtenerEncabezado(codigoIdioma)}</h1>");

        var resumen = formas
            .GroupBy(f => f.GetType())
            .Select(g => new
            {
                Tipo = g.First().ObtenerNombre(g.Count(), codigoIdioma),
                Cantidad = g.Count(),
                AreaTotal = g.Sum(f => f.CalcularArea()),
                PerimetroTotal = g.Sum(f => f.CalcularPerimetro())
            })
            .ToList();

        decimal totalArea = 0, totalPerimetro = 0;
        int totalFormas = 0;

        foreach (var item in resumen)
        {
            sb.Append($"{item.Cantidad} {item.Tipo} | {ObtenerPalabra(ConstantesAplicacion.ClaveArea, codigoIdioma)} {FormatearNumero(item.AreaTotal, codigoIdioma)} | ");
            sb.Append($"{ObtenerPalabra(ConstantesAplicacion.ClavePerimetro, codigoIdioma)} {FormatearNumero(item.PerimetroTotal, codigoIdioma)} <br/>");

            totalFormas += item.Cantidad;
            totalArea += item.AreaTotal;
            totalPerimetro += item.PerimetroTotal;
        }

        sb.Append($"TOTAL:<br/>{totalFormas} {ObtenerPalabra(ConstantesAplicacion.ClaveFormas, codigoIdioma)} | ");
        sb.Append($"{ObtenerPalabra(ConstantesAplicacion.ClavePerimetro, codigoIdioma)} {FormatearNumero(totalPerimetro, codigoIdioma)} | ");
        sb.Append($"{ObtenerPalabra(ConstantesAplicacion.ClaveArea, codigoIdioma)} {FormatearNumero(totalArea, codigoIdioma)}");

        return sb.ToString();
    }

        private static string ObtenerEncabezado(string codigoIdioma)
        {
            switch (codigoIdioma)
            {
                case ConstantesAplicacion.IdiomaEs:
                    return ConstantesAplicacion.EncabezadoEs;
                case ConstantesAplicacion.IdiomaEn:
                    return ConstantesAplicacion.EncabezadoEn;
                case ConstantesAplicacion.IdiomaIt:
                    return ConstantesAplicacion.EncabezadoIt;
                default:
                    return ConstantesAplicacion.EncabezadoEs;
            }
        }
        private static string ObtenerMensajeListaVacia(string codigoIdioma)
        {
            switch (codigoIdioma)
            {
                case ConstantesAplicacion.IdiomaEs:
                    return ConstantesAplicacion.ListaVaciaEs;
                case ConstantesAplicacion.IdiomaEn:
                    return ConstantesAplicacion.ListaVaciaEn;
                case ConstantesAplicacion.IdiomaIt:
                    return ConstantesAplicacion.ListaVaciaIt;
                default:
                    return ConstantesAplicacion.ListaVaciaEs;
            }
        }
        private static string ObtenerPalabra(string key, string codigoIdioma)
        {
            var traducciones = new Dictionary<string, Dictionary<string, string>>
            {
                { ConstantesAplicacion.ClaveFormas, new Dictionary<string, string> {
                    { ConstantesAplicacion.IdiomaEs, ConstantesAplicacion.PalabraFormasEs },
                    { ConstantesAplicacion.IdiomaEn, ConstantesAplicacion.PalabraFormasEn },
                    { ConstantesAplicacion.IdiomaIt, ConstantesAplicacion.PalabraFormasIt }
                }},
                { ConstantesAplicacion.ClaveArea, new Dictionary<string, string> {
                    { ConstantesAplicacion.IdiomaEs, ConstantesAplicacion.PalabraAreaEs },
                    { ConstantesAplicacion.IdiomaEn, ConstantesAplicacion.PalabraAreaEn },
                    { ConstantesAplicacion.IdiomaIt, ConstantesAplicacion.PalabraAreaIt }
                }},
                { ConstantesAplicacion.ClavePerimetro, new Dictionary<string, string> {
                    { ConstantesAplicacion.IdiomaEs, ConstantesAplicacion.PalabraPerimetroEs },
                    { ConstantesAplicacion.IdiomaEn, ConstantesAplicacion.PalabraPerimetroEn },
                    { ConstantesAplicacion.IdiomaIt, ConstantesAplicacion.PalabraPerimetroIt }
                }}
            };

            return traducciones.ContainsKey(key) && traducciones[key].ContainsKey(codigoIdioma)
                ? traducciones[key][codigoIdioma]
                : key;
        }
    }
}
