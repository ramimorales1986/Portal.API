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
    public class MovimientosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovimientosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Movimientos> ObtenerListaPersonas()
        {
            return _unitOfWork.Movimiento.GetAll();
        }
        [HttpPost]
        public IActionResult Agregar(Movimientos movimientos)
        {
            _unitOfWork.Movimiento.Add(movimientos);
            _unitOfWork.Complete();
            return Ok(movimientos);
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Remover(int id)
        {
            Movimientos resultado = _unitOfWork.Movimiento.SingleOrDefault(p => p.movimiento_id == id);

            if (String.IsNullOrEmpty(resultado.ToString()))
            {
                return NoContent();
            }

            _unitOfWork.Movimiento.Remove(resultado);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
