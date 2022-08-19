using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IUnitOfWork
    {
        ICuentaRepository Cuenta { get; }
        IClientRepository Cliente { get; }
        IPersonaRepository Persona { get; }
        IMovimientoRepository Movimiento { get; }

        int Complete();
    }
}
