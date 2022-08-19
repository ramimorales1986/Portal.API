using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface ICuentaRepository : IRepository<Cuenta>
    {
        IEnumerable<Cuenta> GetCuentasClientes(int pagIndex, int pageSize);
    }
}
