using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        #region Properties
        public decimal Base1 { get; set; }
        public decimal Base2 { get; set; }
        public decimal Base3 { get; set; }
        public decimal Base4 { get; set; }
        public decimal Altura { get; set; }
        #endregion
        
        public Trapecio() { }

        public Trapecio(IIdioma idioma) : base(idioma)
        {
            TipoFigura = GrupoFormasGeometricas.tipoFormaGeometrica.Trapecio;
        }

        public override decimal CalcularArea()
        {
            return ((Base1 + Base2) / 2) * Altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (Base1 + Base2 + Base3 + Base4);
        }

        public override string TraducirForma()
        {
            return Idioma.BuscarPalabra("Trapecio");
        }

        public override string TraducirFormaPlural()
        {
            return Idioma.BuscarPalabra("Trapecios");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Idioma.BuscarPalabra("area")} {CalcularArea():#.##} | {Idioma.BuscarPalabra("perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }
    }
}
