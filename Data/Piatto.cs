using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RistoGest.Data
{
    public class Piatto
    {
        public int Id { get; set; }
        public string Tipo_portata { get; set; }
        public string Nome { get; set; }
        public string Allergeni { get; set; }
        public string Stagione { get; set; }
        public decimal Prezzo { get; set; }
    }
}
