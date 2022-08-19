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
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Cliente> ObtenerListaPersonas()
        {
            return _unitOfWork.Cliente.GetAll();
        }
        [HttpPost]
        public IActionResult Agregar(Cliente client)
        {
            _unitOfWork.Cliente.Add(client);
            _unitOfWork.Complete();
            return Ok(client);
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Remover(string id)
        {
            Cliente resultado = _unitOfWork.Cliente.SingleOrDefault(p => p.identificacion == id);

            if (String.IsNullOrEmpty(resultado.ToString()))
            {
                return NoContent();
            }

            _unitOfWork.Cliente.Remove(resultado);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
