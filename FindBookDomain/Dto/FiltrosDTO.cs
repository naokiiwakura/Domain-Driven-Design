using System;
using System.Collections.Generic;
using System.Text;

namespace FindBookDomain.Dto
{
    public class FiltrosDTO
    {
        public string Autor { get; set; }
        public string NomeLivro { get; set; }
        public double? PrecoInicial { get; set; }
        public double? PrecoFinal { get; set; }
        public string Genero { get; set; }
        public string Ilustrador { get; set; }
        public int? QuantidadePaginasInicial { get; set; }
        public int? QuantidadePaginasFinal { get; set; }
    }
}
