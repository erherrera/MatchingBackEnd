using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SaldoResponse
    {
        public string Rpu { get; set; } = string.Empty;

        public decimal Saldo { get; set; }

        public DateOnly FechaCorte { get; set; }
    }
}
