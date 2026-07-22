using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReporteResponse
    {
        public string Folio { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public string Estatus { get; set; } = string.Empty;

        public string TiempoCompromiso { get; set; } = string.Empty;

        public DateOnly Fecha { get; set; }
    }
}
