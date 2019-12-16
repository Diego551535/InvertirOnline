using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Idiomas
{
    public class Idioma : IIdioma
    {
        public enum idioma
        {
            Castellano = 1,
            Ingles = 2
        }

        private static XmlDocument doc = new XmlDocument();
        private static string rutaxml = "Idiomas.xml";
        private idioma _IdiomaDefecto = idioma.Ingles;
        private Idioma() { }
        private Idioma(idioma Idioma)
        {
            _IdiomaDefecto = Idioma;
        }

        public static Idioma Crear(idioma Idioma)
        {
            return new Idioma(Idioma);
        }

        public static Idioma Crear()
        {
            return new Idioma();
        }

        private static void CrearXml()
        {
            XmlDeclaration _declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode _root = doc.DocumentElement;
            doc.InsertBefore(_declaration, _root);

            XmlNode _node = doc.CreateElement("Idiomas");
            doc.AppendChild(_node);
            doc.Save(rutaxml);
        }

        public static void AñadirIdioma(String idioma, string forma, string formas,
                                        string total, string reporteFormas, string listaVaciaFormas,
                                        string area, string perimetro,
                                        string circulo, string circulos,
                                        string triangulo, string triangulos,
                                        string trapecio, string trapecios,
                                        string cuadrado, string cuadrados)
        {
            AbrirArchivo();
            doc.Load(rutaxml);
            XmlNode _Idioma = CrearIdioma(idioma,forma,formas,total,reporteFormas,listaVaciaFormas,
                                          area,perimetro,circulo,circulos,triangulo,triangulos,trapecio,trapecios,cuadrado,cuadrados);
            XmlNode _NodoRiz = doc.DocumentElement;
            _NodoRiz.InsertAfter(_Idioma, _NodoRiz.LastChild);
            doc.Save(rutaxml);
        }

        private static void AbrirArchivo()
        {
            if (!File.Exists(rutaxml))
                CrearXml();
        }

        private static XmlNode CrearIdioma(String idioma, string forma, string formas,
                                        string total, string reporteFormas, string listaVaciaFormas,
                                        string area, string perimetro,
                                        string circulo, string circulos,
                                        string triangulo, string triangulos,
                                        string trapecio, string trapecios,
                                        string cuadrado, string cuadrados)
        {
            XmlNode _Idioma = doc.CreateElement(idioma);

            XmlElement _Forma = doc.CreateElement("Forma");
            _Forma.InnerText = forma;
            _Idioma.AppendChild(_Forma);

            XmlElement _Formas = doc.CreateElement("Formas");
            _Formas.InnerText = formas;
            _Idioma.AppendChild(_Formas);

            XmlElement _Total = doc.CreateElement("Total");
            _Total.InnerText = total;
            _Idioma.AppendChild(_Total);

            XmlElement _ReporteFormas = doc.CreateElement("ReporteFormas");
            _ReporteFormas.InnerText = reporteFormas;
            _Idioma.AppendChild(_ReporteFormas);

            XmlElement _ListaVaciaFormas = doc.CreateElement("ListaVaciaFormas");
            _ListaVaciaFormas.InnerText = listaVaciaFormas;
            _Idioma.AppendChild(_ListaVaciaFormas);

            XmlElement _Area = doc.CreateElement("Area");
            _Area.InnerText = area;
            _Idioma.AppendChild(_Area);

            XmlElement _Perimetro = doc.CreateElement("Perimetro");
            _Perimetro.InnerText = perimetro;
            _Idioma.AppendChild(_Perimetro);

            XmlElement _Circulo = doc.CreateElement("Circulo");
            _Circulo.InnerText = circulo;
            _Idioma.AppendChild(_Circulo);

            XmlElement _Circulos = doc.CreateElement("Circulos");
            _Circulos.InnerText = circulos;
            _Idioma.AppendChild(_Circulos);

            XmlElement _Triangulo = doc.CreateElement("Triangulo");
            _Triangulo.InnerText = triangulo;
            _Idioma.AppendChild(_Triangulo);

            XmlElement _Triangulos = doc.CreateElement("Triangulos");
            _Triangulos.InnerText = triangulos;
            _Idioma.AppendChild(_Triangulos);

            XmlElement _Trapecio = doc.CreateElement("Trapecio");
            _Trapecio.InnerText = trapecio;
            _Idioma.AppendChild(_Trapecio);

            XmlElement _Trapecios = doc.CreateElement("Trapecios");
            _Trapecios.InnerText = trapecios;
            _Idioma.AppendChild(_Trapecios);

            XmlElement _Cuadrado = doc.CreateElement("Cuadrado");
            _Cuadrado.InnerText = cuadrado;
            _Idioma.AppendChild(_Cuadrado);

            XmlElement _Cuadrados = doc.CreateElement("Cuadrados");
            _Cuadrados.InnerText = cuadrados;
            _Idioma.AppendChild(_Cuadrados);

            return _Idioma;
        }

        public idioma IdiomaActual
        {
            get
            {
                return _IdiomaDefecto;
            }
        }
        public void SetIdioma(idioma Idioma)
        {
            _IdiomaDefecto = Idioma;
        }
        public string BuscarPalabra(string key)
        {
            string _return = String.Empty;
            XmlTextReader reader = new XmlTextReader(rutaxml);
            _return = BuscarIdioma(reader, key);
            return _return;
        }

        private string BuscarIdioma(XmlTextReader reader, string key)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (_IdiomaDefecto.ToString() == reader.Name)
                    {
                        return BuscarPalabra(reader, key);
                    }
                }
            }
            return string.Empty;
        }

        private string BuscarPalabra(XmlTextReader reader,string key)
        {
            string _return = string.Empty;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (key == reader.Name)
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Text)
                            {
                                return  reader.Value;
                            }
                        }
                    }
                }
            }
            return _return;
        }
    }
}
