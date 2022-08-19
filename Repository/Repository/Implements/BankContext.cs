using Microsoft.EntityFrameworkCore;
using SistemaBancario.Model;

namespace Repositorio.Implements
{
    public class BankContext :DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }

        public DbSet<Persona> Persona { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Data Source= .\sqlExpress;Initial Catalog = Academic;Integrated Security = True, TrustedServerCertificate = true");
            options.UseSqlServer(@"Data Source= .\sqlExpress;Initial Catalog = Bank;Integrated Security = True");
        }

    }
}
