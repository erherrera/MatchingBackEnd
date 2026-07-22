using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CatalogoFallaResponse
    {
        public string Codigo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;
    }

    public class ReporteFallaRequest
    {
        public string TipoFalla { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Comentarios { get; set; } = string.Empty;
    }

    public class ReporteFallaResponse
    {
        public string NumeroOrden { get; set; } = string.Empty;

        public string TiempoCompromiso { get; set; } = string.Empty;
    }
}
