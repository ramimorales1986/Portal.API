using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        public Persona Obtener(int id);
    }
}
