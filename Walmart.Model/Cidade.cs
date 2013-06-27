using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Walmart.Entity
{
    [Serializable]
    public class Cidade
    {
        
        public int Codigo { get; set; }
        
        public int CodEstado { get; set; }
        
        public Estado Estado { get; set; }
        
        public string Nome { get; set; }
        
        public bool Capital { get; set; }
    }
}
