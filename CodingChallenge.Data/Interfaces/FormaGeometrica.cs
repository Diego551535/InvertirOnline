using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal Lado { get; set; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string TraducirForma();
    }
}
