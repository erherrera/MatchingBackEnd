using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReconexionConsultaResponse
    {
        public string Estatus { get; set; } = string.Empty;

        public bool Elegible { get; set; }

        public bool ConAdeudo { get; set; }

        public decimal? Importe { get; set; }

        public string Moneda { get; set; } = "MXN";

        public PagoInfo? Pago { get; set; }
    }

    public class PagoInfo
    {
        public string Url { get; set; } = string.Empty;

        public string Etiqueta { get; set; } = string.Empty;
    }

    public class ReconexionResponse
    {
        public string NumeroOrden { get; set; } = string.Empty;

        public string TiempoCompromiso { get; set; } = string.Empty;
    }

}
