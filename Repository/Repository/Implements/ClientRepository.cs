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
    public class ClientRepository : Repository<Cliente>,IClientRepository
    {

        private readonly BankContext _context;

        public ClientRepository(DbContext context) : base(context) { 
        
            _context = (BankContext)context;
        }

        public Cliente GetInfoClient(int clienteId)
        {
            var client = _context.Cliente.Find(clienteId);
            _context.Entry(client).Reference(a => a.Persona);
            return client;
        }
    }
}
