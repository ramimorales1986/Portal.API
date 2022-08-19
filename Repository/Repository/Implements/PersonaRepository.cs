using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implements
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        private readonly BankContext _context;
        public PersonaRepository(DbContext context) : base(context)
        {
            _context = (BankContext)context;
        }

        public Persona Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
