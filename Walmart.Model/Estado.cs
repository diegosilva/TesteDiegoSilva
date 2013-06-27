using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Walmart.Entity
{
    [Serializable]
    public class Estado
    {
        public int Codigo { get; set; }
                
        public string Pais { get; set; }
        
        public string Nome { get; set; }
        
        public string Sigla { get; set; }
        
        public string Regiao { get; set; }
    }
}
