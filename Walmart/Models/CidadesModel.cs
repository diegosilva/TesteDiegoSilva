using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Walmart.Models
{
    public class CidadesModel
    {
        public class Cidade
        {

            public int Codigo { get; set; }

            public int CodEstado { get; set; }

            public EstadosModel Estado { get; set; }

            public string Nome { get; set; }

            public bool Capital { get; set; }
        }
    }
}