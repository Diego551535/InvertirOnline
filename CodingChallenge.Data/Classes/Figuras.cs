using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Figuras : List<GrupoFormasGeometricas>
    {
        private decimal _sumaArea = 0;
        private decimal _sumaPerimetro = 0;
        private Figuras() { }

        public static Figuras CrearVacia()
        {
            return new Figuras();
        }
        internal void CalcularAreaPerimetro()
        {
            if(this.Count > 0)
                AreaPerimetro();
        }

        private void AreaPerimetro()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].CalcularAreaPerimetro();
                _sumaArea += this[i].Area;
                _sumaPerimetro += this[i].Perimetro;
            }
        }

        public int GetListCount()
        {
            return this.Count;
        }

        public void Add(FormaGeometrica forma)
        {
            this.Add(forma);
        }

        public void Remove(FormaGeometrica forma)
        {
            this.Remove(forma);
        }

        internal string ObtenerLineas()
        {
            string _return = string.Empty;
            if(this.Count > 0)
            {
                foreach (var item in this)
                {
                    _return += item.ObtenerLineas();
                }
            }
            return _return;
        }

        internal int CantidadFormas
        {
            get
            {
                int _return = 0;
                foreach (var item in this)
                {
                    _return += item.Numero;
                }
                return _return;
            }
        }

        internal decimal SumaAreas
        {
            get
            {
                return _sumaArea;
            }
        }

        internal decimal SumaPerimetros
        {
            get
            {
                return _sumaPerimetro;
            }
        }
    }
}
