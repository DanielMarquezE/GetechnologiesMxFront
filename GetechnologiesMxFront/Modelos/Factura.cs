using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMxFront.Modelos
{
    internal class Factura
    {

        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public int? IdPersona { get; set; }

    }
}
