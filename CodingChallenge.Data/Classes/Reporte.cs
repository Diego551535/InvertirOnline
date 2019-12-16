using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Reporte
    {
        private static Figuras _Figuras = null;
        private static StringBuilder _StringBuilder = null;
        public static IIdioma Idioma { get; set; }
        public Reporte(IIdioma idioma)
        {
            Idioma = idioma;
        }
        public static string Imprimir(Figuras Figuras)
        {
            _Figuras = Figuras;
            _StringBuilder = new StringBuilder();

            if (_Figuras != null && !_Figuras.Any())
            {
                _StringBuilder.Append(CrearCabecera());
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                _StringBuilder.Append(CrearTitulo());
                // Cuerpo
                CrearCuerpo();

                // FOOTER
                CrearFin();
            }

            return _StringBuilder.ToString();
        }

        private static void CrearFin()
        {
            _StringBuilder.Append(Idioma.BuscarPalabra("Total"));
            _StringBuilder.Append(_Figuras.CantidadFormas + " " + Idioma.BuscarPalabra("Formas") + " ");
            _StringBuilder.Append(Idioma.BuscarPalabra("Perimetro")+" " + (_Figuras.SumaPerimetros).ToString("#.##") + " ");
            _StringBuilder.Append(Idioma.BuscarPalabra("Area")+ " " + (_Figuras.SumaAreas).ToString("#.##"));
        }

        private static void CrearCuerpo()
        {
            if (_Figuras != null)
            {
                _Figuras.CalcularAreaPerimetro();
                CrearLineas();
            }
            else
                throw new Exception("Sin Formas Geometricas");
        }
        private static void CrearLineas()
        {
            _StringBuilder.Append(_Figuras.ObtenerLineas());
            //_StringBuilder.Append(ObtenerLinea(_Figuras.NumeroCirculos, _Figuras.AreaCirculos, _Figuras.PerimetroCirculos, FormaGeometrica.FormaGeometrica.Circulo, idioma));
            //_StringBuilder.Append(ObtenerLinea(_Figuras.NumeroTriangulos, _Figuras.AreaTriangulos, _Figuras.PerimetroTriangulos, FormaGeometrica.FormaGeometrica.TrianguloEquilatero, idioma));
        }

        private static string CrearTitulo()
        {
            //if (idioma == Idioma.Castellano)
            //    return "<h1>Reporte de Formas</h1>";
            //else
            //    // default es inglés
            //    return "<h1>Shapes report</h1>";
            return Idioma.BuscarPalabra("ReporteFormas");
        }

        private static string CrearCabecera()
        {
            //if (idioma == Idioma.Castellano)
            //    return "<h1>Lista vacía de formas!</h1>";
            //else
            //    return "<h1>Empty list of shapes!</h1>";
            return Idioma.BuscarPalabra("ListaVaciaFormas");
        }
    }
}
