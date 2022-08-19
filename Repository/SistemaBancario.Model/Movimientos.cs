using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Movimientos
    {
        public int id { get; set; }
        public int movimiento_id { get; set; }
        public DateTime fecha { get; set; }
        public string tipo_movimiento { get; set; }
        public decimal valor { get; set; }
        public decimal saldo { get; set; }
        public Boolean estado_movimento { get; set; }
        public string numero_cuenta { get; set; }
        public virtual Cuenta Cuenta { get; set; }
    }
}
