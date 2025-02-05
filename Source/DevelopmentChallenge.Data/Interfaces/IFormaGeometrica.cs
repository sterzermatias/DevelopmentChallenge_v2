using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Classes;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string ObtenerNombre(int cantidad, string codigoIdioma);
    }
}
