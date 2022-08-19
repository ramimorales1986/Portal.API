using System;
using Repositorio.Interfaces;
using Repositorio.Implements;
using SistemaBancario.Model;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IUnitOfWork UOW = new UnitOfWork(new BankContext());
            var personaNew = new Persona { identificacion = "1714882782", nombre = "Fernanda UAX", genero = "M", direccion = "XXX", telefono = "0908077" };
            UOW.Persona.Add(personaNew);
            var personasNew = UOW.Persona.GetAll();
            UOW.Complete();
            var personas1New = UOW.Persona.GetAll();
            Console.WriteLine(personaNew.nombre);
        }
    }
}


