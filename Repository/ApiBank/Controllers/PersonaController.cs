using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfaces;
using SistemaBancario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> ObtenerListaPersonas()
        {
            return _unitOfWork.Persona.GetAll();
        }
        [HttpPost]
        public IActionResult Agregar(Persona person)
        {
            _unitOfWork.Persona.Add(person);
            _unitOfWork.Complete();
            return Ok(person);
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Remover(string identificacion)
        {
            Persona resultado = _unitOfWork.Persona.SingleOrDefault(p => p.identificacion == identificacion);

            if (String.IsNullOrEmpty(resultado.ToString()))
            {
                return NoContent();
            }

            _unitOfWork.Persona.Remove(resultado);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPut("{identificacion}")]
        public async Task<IActionResult> Update(string identificacion, Persona Persona)
        {


            Persona resultado = _unitOfWork.Persona.SingleOrDefault(p => p.identificacion == identificacion);

            if (String.IsNullOrEmpty(resultado.ToString()))
            {
                return NoContent();
            }

            
            _unitOfWork.Persona.Add(Persona);
            _unitOfWork.Complete();


            return Ok(resultado);
        }
    }

       
}
