using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using Idiomas;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestCrearXMLidiomas()
        {
            //Idioma.AñadirIdioma("Castellano", "forma", "formas", "TOTAL:<br/>", "<h1>Reporte de Formas</h1>", "<h1>Lista vacía de formas!</h1>", "Area", "Perimetro", "Círculo", "Círculos", "Triángulo", "Triángulos", "Trapecio", "Trapecios", "Cuadrado", "Cuadrados");
            //Idioma.AñadirIdioma("Ingles", "shape", "shapes", "TOTAL:<br/>", "<h1>Shapes report</h1>", "<h1>Empty list of shapes!</h1>", "Area", "Perimeter", "Circle", "Circles", "Triangle", "Triangles", "Trapezium", "Trapeziums", "Square", "Squares");
        }
        [TestCase]
        public void TestResumenListaVacia()
        {
            //Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
            //    FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));

            Reporte.Idioma = Idioma.Crear(Idioma.idioma.Castellano);
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", Reporte.Imprimir(Figuras.CrearVacia()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            //Assert.AreEqual("<h1>Empty list of shapes!</h1>",
            //    FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));

            Reporte.Idioma = Idioma.Crear();
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", Reporte.Imprimir(Figuras.CrearVacia()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            //var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(FormaGeometrica.Cuadrado, 5)};

            //var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            //Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);

            Idioma idioma = Idioma.Crear(Idioma.idioma.Castellano);
            Cuadrado Cuadrado1 = Cuadrado.CrearNuevo(5, idioma);

            Figuras figuras = Figuras.CrearVacia();
            GrupoFormasGeometricas GrupoCuadrados = GrupoFormasGeometricas.CrearGrupo();
            GrupoCuadrados.Add(Cuadrado1);
            figuras.Add(GrupoCuadrados);
            Reporte.Idioma = idioma;
            var resumen = Reporte.Imprimir(figuras);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            //var cuadrados = new List<FormaGeometrica>
            //{
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            //};

            //var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            //Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);

            Idioma idioma = Idioma.Crear();
            Cuadrado Cuadrado1 = Cuadrado.CrearNuevo(5, idioma);
            Cuadrado Cuadrado2 = Cuadrado.CrearNuevo(1, idioma);
            Cuadrado Cuadrado3 = Cuadrado.CrearNuevo(3, idioma);

            Figuras figuras = Figuras.CrearVacia();
            GrupoFormasGeometricas GrupoCuadrados = GrupoFormasGeometricas.CrearGrupo();
            GrupoCuadrados.Add(Cuadrado1);
            GrupoCuadrados.Add(Cuadrado2);
            GrupoCuadrados.Add(Cuadrado3);
            figuras.Add(GrupoCuadrados);
            Reporte.Idioma = idioma;
            var resumen = Reporte.Imprimir(figuras);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);

        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            //var formas = new List<FormaGeometrica>
            //{
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
            //    new FormaGeometrica(FormaGeometrica.Circulo, 3),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
            //    new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            //};

            //var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            //Assert.AreEqual(
            //    "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
            ////resumen);
            ///

            Idioma idioma = Idioma.Crear();
            Cuadrado Cuadrado1 = Cuadrado.CrearNuevo(5, idioma);
            Cuadrado Cuadrado2 = Cuadrado.CrearNuevo(2, idioma);
            Circulo Circulo1 = Circulo.CrearNuevo(3, idioma);
            Circulo Circulo2 = Circulo.CrearNuevo(2.75m, idioma);
            TrianguloEquilatero Triangulo1 = TrianguloEquilatero.CrearNuevo(4, idioma);
            TrianguloEquilatero Triangulo2 = TrianguloEquilatero.CrearNuevo(9, idioma);
            TrianguloEquilatero Triangulo3 = TrianguloEquilatero.CrearNuevo(4.2m, idioma);

            Figuras figuras = Figuras.CrearVacia();
            GrupoFormasGeometricas GrupoCuadrados = GrupoFormasGeometricas.CrearGrupo();
            GrupoFormasGeometricas GrupoCirculos = GrupoFormasGeometricas.CrearGrupo();
            GrupoFormasGeometricas GrupoTriangulos = GrupoFormasGeometricas.CrearGrupo();
            GrupoCuadrados.Add(Cuadrado1);
            GrupoCuadrados.Add(Cuadrado2);
            GrupoCirculos.Add(Circulo1);
            GrupoCirculos.Add(Circulo2);
            GrupoTriangulos.Add(Triangulo1);
            GrupoTriangulos.Add(Triangulo2);
            GrupoTriangulos.Add(Triangulo3);
            figuras.Add(GrupoCuadrados);
            figuras.Add(GrupoCirculos);
            figuras.Add(GrupoTriangulos);
            Reporte.Idioma = idioma;
            var resumen = Reporte.Imprimir(figuras);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
            resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            //var formas = new List<FormaGeometrica>
            //{
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
            //    new FormaGeometrica(FormaGeometrica.Circulo, 3),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
            //    new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
            //    new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
            //    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            //};

            //var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            //Assert.AreEqual(
            //    "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
            //    resumen);

            Idioma idioma = Idioma.Crear(Idioma.idioma.Castellano);
            Cuadrado Cuadrado1 = Cuadrado.CrearNuevo(5, idioma);
            Cuadrado Cuadrado2 = Cuadrado.CrearNuevo(2, idioma);
            Circulo Circulo1 = Circulo.CrearNuevo(3, idioma);
            Circulo Circulo2 = Circulo.CrearNuevo(2.75m, idioma);
            TrianguloEquilatero Triangulo1 = TrianguloEquilatero.CrearNuevo(4, idioma);
            TrianguloEquilatero Triangulo2 = TrianguloEquilatero.CrearNuevo(9, idioma);
            TrianguloEquilatero Triangulo3 = TrianguloEquilatero.CrearNuevo(4.2m, idioma);

            Figuras figuras = Figuras.CrearVacia();
            GrupoFormasGeometricas GrupoCuadrados = GrupoFormasGeometricas.CrearGrupo();
            GrupoFormasGeometricas GrupoCirculos = GrupoFormasGeometricas.CrearGrupo();
            GrupoFormasGeometricas GrupoTriangulos = GrupoFormasGeometricas.CrearGrupo();
            GrupoCuadrados.Add(Cuadrado1);
            GrupoCuadrados.Add(Cuadrado2);
            GrupoCirculos.Add(Circulo1);
            GrupoCirculos.Add(Circulo2);
            GrupoTriangulos.Add(Triangulo1);
            GrupoTriangulos.Add(Triangulo2);
            GrupoTriangulos.Add(Triangulo3);
            figuras.Add(GrupoCuadrados);
            figuras.Add(GrupoCirculos);
            figuras.Add(GrupoTriangulos);
            Reporte.Idioma = idioma;
            var resumen = Reporte.Imprimir(figuras);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
            resumen);
        }
    }
}
