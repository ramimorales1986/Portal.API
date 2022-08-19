using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BankContext _context;
        public readonly ICuentaRepository _cuenta;
        public readonly IPersonaRepository _persona;
        public readonly IClientRepository _client;
        public readonly IMovimientoRepository _movimiento;

        public UnitOfWork(BankContext context)
        {
            _context = context;
            _cuenta = new CuentaRepository(context);
            _persona = new PersonaRepository(context);
            _client = new ClientRepository(context);
            _movimiento = new MovimientosRepository(context);
        }

        public ICuentaRepository Cuenta => _cuenta;

        public IClientRepository Cliente => _client;

        public IPersonaRepository  Persona => _persona;
        public IMovimientoRepository Movimiento => _movimiento;

        public int Complete() => _context.SaveChanges();
    }
}
