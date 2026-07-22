using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ValidateRequest
    {
        public string? Rpu { get; set; }

        public string? RpuToken { get; set; }

        public string NumeroMedidor { get; set; } = string.Empty;

        public string NombreTitular { get; set; } = string.Empty;
    }

    public class ValidateResponse
    {
        public string OwnershipToken { get; set; } = string.Empty;
    }
}
