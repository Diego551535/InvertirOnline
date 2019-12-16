using CodingChallenge.Data.Interfaces;
using Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica : IFormaGeometrica
    {
        public readonly IIdioma Idioma;
        public GrupoFormasGeometricas.tipoFormaGeometrica TipoFigura { get; set; }
        public decimal Lado { get; set; }

        public FormaGeometrica() { }
        public FormaGeometrica(IIdioma idioma)
        {
            Idioma = idioma;
        }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public virtual string TraducirForma()
        {
            throw new NotImplementedException();
        }

        public virtual string TraducirFormaPlural()
        {
            throw new NotImplementedException();
        }

        public virtual string ObtenerLinea()
        {
            throw new NotImplementedException();
        }

        public virtual int GetListCount()
        {
            throw new NotImplementedException();
        }
        public string BuscarPalabraArea()
        {
            return Idioma.BuscarPalabra("Area");
        }

        public string BuscarPalabraPerimetro()
        {
            return Idioma.BuscarPalabra("Perimetro");
        }

    }
}
