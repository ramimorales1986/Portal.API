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
    public class MovimientosRepository : Repository<Movimientos>, IMovimientoRepository
    {
        private readonly BankContext _context;
        public MovimientosRepository(DbContext context) : base(context)
        {
            _context = (BankContext)context;
        }
    }
}
