using CodingChallenge.Data.Interfaces;
using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private Circulo(decimal lado, IIdioma idioma):this(idioma)
        {
            Lado = lado;
        }
        public Circulo() { }

        public Circulo(IIdioma idioma):base(idioma)
        {
            TipoFigura = GrupoFormasGeometricas.tipoFormaGeometrica.Circulo;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }

        public override string TraducirForma()
        {
            return Idioma.BuscarPalabra("Circulo");
        }

        public override string TraducirFormaPlural()
        {
            return Idioma.BuscarPalabra("Circulos");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Idioma.BuscarPalabra("area")} {CalcularArea():#.##} | {Idioma.BuscarPalabra("perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }
        public static Circulo CrearNuevo(decimal lado, IIdioma idioma)
        {
            return new Circulo(lado, idioma);
        }
    }
}
