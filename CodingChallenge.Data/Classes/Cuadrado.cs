using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private Cuadrado(decimal lado, IIdioma idioma):this(idioma)
        {
            Lado = lado;
        }

        public Cuadrado(IIdioma idioma) : base(idioma)
        {
            TipoFigura = GrupoFormasGeometricas.tipoFormaGeometrica.Cuadrado;
        }

        public override decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
        }

        public override string TraducirForma()
        {
            return Idioma.BuscarPalabra("Cuadrado");
        }

        public override string TraducirFormaPlural()
        {
            return Idioma.BuscarPalabra("Cuadrados");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Idioma.BuscarPalabra("Area")} {CalcularArea():#.##} | {Idioma.BuscarPalabra("Perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }
        public static Cuadrado CrearNuevo(decimal lado, IIdioma idioma)
        {
            return new Cuadrado(lado,idioma);
        }
    }
}
