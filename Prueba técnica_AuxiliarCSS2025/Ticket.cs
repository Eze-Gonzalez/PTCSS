using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_técnica_AuxiliarCSS2025
{
    internal class Ticket
    {
        public Agente ag = new Agente();
        public Tipo tipo = new Tipo();
        public int id { get; set; }
        public DateTime creacion {  get; set; }
        public DateTime cierre { get; set; }
        public bool resueltook {  get; set; }
    }
}
