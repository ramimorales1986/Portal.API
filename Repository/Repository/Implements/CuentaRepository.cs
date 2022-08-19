using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implements
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {
        private readonly BankContext _context;
        public CuentaRepository(DbContext context) : base(context)
        {
            _context = (BankContext)context;
        }

        public IEnumerable<Cuenta> GetCuentasClientes(int pagIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
