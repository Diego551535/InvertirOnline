using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private TrianguloEquilatero(decimal lado, IIdioma idioma) : this(idioma)
        {
            Lado = lado;
        }
        public TrianguloEquilatero() { }

        public TrianguloEquilatero(IIdioma idioma) : base(idioma)
        {
            TipoFigura = GrupoFormasGeometricas.tipoFormaGeometrica.TrianguloEquilatero;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }

        public override string TraducirForma()
        {
            return Idioma.BuscarPalabra("Triangulo");
        }

        public override string TraducirFormaPlural()
        {
            return Idioma.BuscarPalabra("Triangulos");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Idioma.BuscarPalabra("area")} {CalcularArea():#.##} | {Idioma.BuscarPalabra("perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }
        
        public static TrianguloEquilatero CrearNuevo(decimal lado, IIdioma idioma)
        {
            return new TrianguloEquilatero(lado, idioma);
        }
    }
}
