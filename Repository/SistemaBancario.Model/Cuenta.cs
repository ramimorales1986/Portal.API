using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Cuenta
    {
        public int id { get; set; }
        public string numero_cuenta { get; set; }
        public string tipo_cuenta { get; set; }
        public decimal saldo_inicial { get; set; }
        public Boolean estado_cuenta { get; set; }
        public int cliente_id { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
    }
}
