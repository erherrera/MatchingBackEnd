using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IdentifyRequest
    {
        public string Telefono { get; set; } = string.Empty;
    }

    public class ServicioResponse
    {
        public string RpuToken { get; set; } = string.Empty;
        public string RpuMascarado { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
    }

    public class IdentifyResponse
    {
        public List<ServicioResponse> Servicios { get; set; } = [];
        public bool Truncado { get; set; }
    }
}
