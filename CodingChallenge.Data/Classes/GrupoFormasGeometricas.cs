using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Data.Classes;

namespace CodingChallenge.Data.Classes
{
    public class GrupoFormasGeometricas : List<FormaGeometrica>
    {
        int _numero = 0;
        decimal _totalarea = 0m;
        decimal _totalperimetro = 0m;
        public enum tipoFormaGeometrica
        {
            Cuadrado = 1,
            TrianguloEquilatero = 2,
            Circulo = 3,
            Trapecio = 4
        }
        tipoFormaGeometrica _TipoFormas;

        public int Numero
        {
            get
            {
                return _numero;
            }
        }
        public decimal Area
        {
            get
            {
                return _totalarea;
            }
        }
        public decimal Perimetro
        {
            get
            {
                return _totalperimetro;
            }
        }

        internal void CalcularAreaPerimetro()
        {
            if(this.Count > 0)
            {
                foreach (var item in this)
                {
                    _numero++;
                    _totalarea += item.CalcularArea();
                    _totalperimetro += item.CalcularPerimetro();
                }
            }
        }
        public static GrupoFormasGeometricas CrearGrupo()
        {
            return new GrupoFormasGeometricas();
        }

        internal string ObtenerLineas()
        {
            string _return = String.Empty;
            //if(this.Count > 0)
            //{
            //    foreach (var item in this)
            //    {
            //        if(_return == String.Empty)
            //            _return = item.ObtenerLinea();
            //        else
            //        {
            //            _return = "\n" + item.ObtenerLinea();
            //        }
            //    }
            //}
            if(this.Count > 0)
                _return =  $"{this.Count} {TraducirForma()} | {this[0].BuscarPalabraArea()} {_totalarea:#.##} | {this[0].BuscarPalabraPerimetro()} {_totalperimetro:#.##} <br/>";
            return _return;
        }

        private string TraducirForma()
        {
            return this.Count == 1 ? this[0].TraducirForma() : this[0].TraducirFormaPlural();
        }

        public new void Add(FormaGeometrica FormaGeometrica)
        {
            base.Add(FormaGeometrica);
            if (this.Count == 1)
                _TipoFormas = this[0].TipoFigura;
        }
    }
}
