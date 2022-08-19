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
    public class CuentaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CuentaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Cuenta> ObtenerListaPersonas()
        {
            return _unitOfWork.Cuenta.GetAll();
        }
        [HttpPost]
        public IActionResult Agregar(Cuenta cuenta)
        {
            _unitOfWork.Cuenta.Add(cuenta);
            _unitOfWork.Complete();
            return Ok(cuenta);
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Remover(string id)
        {
            Cuenta resultado = _unitOfWork.Cuenta.SingleOrDefault(p => p.numero_cuenta == id);

            if (String.IsNullOrEmpty(resultado.ToString()))
            {
                return NoContent();
            }

            _unitOfWork.Cuenta.Remove(resultado);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
