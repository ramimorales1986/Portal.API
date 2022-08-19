using System;

namespace SistemaBancario.Model
{
    public class Cliente
    {
        public int id { get; set; }
        public int cliente_id { get; set; }
        public string contrasenia { get; set; }
        public Boolean estado_cliente { get; set; }
        public string identificacion { get; set; }
        public Persona Persona { get; set; }


    }
}
