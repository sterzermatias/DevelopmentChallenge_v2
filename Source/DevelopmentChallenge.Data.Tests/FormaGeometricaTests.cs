using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;
using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Utils;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class FormaGeometricaTests
    {
        private GeneradorReporte _generadorReporte;
        private Validador _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new Validador();
            _generadorReporte = new GeneradorReporte(_validador);
        }

        [Test]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                _generadorReporte.Imprimir(new List<IFormaGeometrica>(), ConstantesAplicacion.IdiomaEs));
        }

        [Test]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                _generadorReporte.Imprimir(new List<IFormaGeometrica>(), ConstantesAplicacion.IdiomaEn));
        }

        [Test]
        public void TestResumenListaConUnCuadrado()
        {
            var formas = new List<IFormaGeometrica> { new Cuadrado(5, _validador) };

            var resumen = _generadorReporte.Imprimir(formas, ConstantesAplicacion.IdiomaEs);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas | Perímetro 20 | Área 25", resumen);
        }

        [Test]
        public void TestResumenListaConMasCuadrados()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, _validador),
                new Cuadrado(1, _validador),
                new Cuadrado(3, _validador)
            };

            var resumen = _generadorReporte.Imprimir(formas, ConstantesAplicacion.IdiomaEn);

            Assert.AreEqual("<h1>Shapes Report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes | Perimeter 36 | Area 35", resumen);
        }

        [Test]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, _validador),
                new Circulo(3, _validador),
                new TrianguloEquilatero(4, _validador),
                new Cuadrado(2, _validador),
                new TrianguloEquilatero(9, _validador),
                new Circulo(2.75m, _validador),
                new TrianguloEquilatero(4.2m, _validador)
            };

            var resumen = _generadorReporte.Imprimir(formas, ConstantesAplicacion.IdiomaEn);

            Assert.AreEqual(
                "<h1>Shapes Report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52.03 | Perimeter 36.13 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes | Perimeter 115.73 | Area 130.67",
                resumen);
        }

        [Test]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5, _validador),
                new Circulo(3, _validador),
                new TrianguloEquilatero(4, _validador),
                new Cuadrado(2, _validador),
                new TrianguloEquilatero(9, _validador),
                new Circulo(2.75m, _validador),
                new TrianguloEquilatero(4.2m, _validador)
            };

            var resumen = _generadorReporte.Imprimir(formas, ConstantesAplicacion.IdiomaEs);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 52,03 | Perímetro 36,13 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas | Perímetro 115,73 | Área 130,67",
                resumen);
        }

        [Test]
        public void TestResumenListaConTrapecioYRectangulo()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Trapecio(10, 6, 4, 5, 5, _validador),
                new Rectangulo(5, 3, _validador)
            };

            var resumen = _generadorReporte.Imprimir(formas, ConstantesAplicacion.IdiomaEs);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Área 32 | Perímetro 26 <br/>1 Rectángulo | Área 15 | Perímetro 16 <br/>TOTAL:<br/>2 formas | Perímetro 42 | Área 47",
                resumen);
        }

        [Test]
        public void TestValidador_LanzaExcepcion_CantidadInvalida()
        {
            Assert.Throws<ArgumentException>(() => new Cuadrado(5, _validador).ObtenerNombre(0, ConstantesAplicacion.IdiomaEs));
        }

        [Test]
        public void TestValidador_LanzaExcepcion_IdiomaNoSoportado()
        {
            Assert.Throws<ArgumentException>(() => new Cuadrado(5, _validador).ObtenerNombre(1, ConstantesAplicacion.IdiomaFr));
        }

        [Test]
        public void Cuadrado_CalculaArea_Correctamente()
        {
            var cuadrado = new Cuadrado(4, _validador);
            Assert.AreEqual(16, cuadrado.CalcularArea());
        }

        [Test]
        public void Circulo_CalculaArea_Correctamente()
        {
            var circulo = new Circulo(3, _validador);
            Assert.AreEqual(Math.PI * 3 * 3, (double)circulo.CalcularArea(), 0.01);
        }

        [Test]
        public void TrianguloEquilatero_CalculaArea_Correctamente()
        {
            var triangulo = new TrianguloEquilatero(4, _validador);
            Assert.AreEqual((Math.Sqrt(3) / 4) * 4 * 4, (double)triangulo.CalcularArea(), 0.01);
        }

        [Test]
        public void GeneradorReporte_ListaVacia_EnEspanol()
        {
            var resultado = _generadorReporte.Imprimir(new List<IFormaGeometrica>(), ConstantesAplicacion.IdiomaEs);
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resultado);
        }

        [Test]
        public void GeneradorReporte_ListaVacia_EnIngles()
        {
            var resultado = _generadorReporte.Imprimir(new List<IFormaGeometrica>(), ConstantesAplicacion.IdiomaEn);
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resultado);
        }

        [Test]
        public void Cuadrado_ValorNegativo_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() => new Cuadrado(-5, _validador));
        }

        [Test]
        public void Circulo_ValorCero_LanzaExcepcion()
        {
            Assert.Throws<ArgumentException>(() => new Circulo(0, _validador));
        }



    }
}
