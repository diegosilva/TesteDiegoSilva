using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Walmart.Models
{
    public class EstadosModel
    {
        public int Codigo { get; set; }

        public string Pais { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string Regiao { get; set; }
    }
}