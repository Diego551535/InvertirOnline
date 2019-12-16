using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Idiomas.Idioma;

namespace Idiomas
{
    public interface IIdioma
    {
        idioma IdiomaActual { get; }
        void SetIdioma(idioma culture);
        string BuscarPalabra(string key);
    }
}
