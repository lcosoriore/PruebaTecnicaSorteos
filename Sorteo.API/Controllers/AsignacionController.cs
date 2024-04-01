using Microsoft.AspNetCore.Mvc;
using Sorteo.Application.Services;
using Sorteo.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Sorteo.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar las asignaciones de números de sorteo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : ControllerBase
    {
        private readonly AsignacionService _asignacionService;

        /// <summary>
        /// Constructor de la clase <see cref="AsignacionController"/>.
        /// </summary>
        /// <param name="asignacionService">Servicio de asignación.</param>
        public AsignacionController(AsignacionService asignacionService)
        {
            _asignacionService = asignacionService ?? throw new ArgumentNullException(nameof(asignacionService));
        }

        /// <summary>
        /// Asigna un número de sorteo.
        /// </summary>
        /// <param name="asignacionDto">Datos de la asignación.</param>
        /// <returns>Una acción de resultado que representa el resultado de la operación.</returns>
        /// <response code="200">Se ha realizado la asignación correctamente.</response>
        /// <response code="400">La solicitud es incorrecta debido a datos inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Asignacion), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Asignacion>> AsignarNumero([FromBody] Asignacion asignacionDto)
        {
            try
            {
                var asignacion = await _asignacionService.AsignarNumeroAsync(asignacionDto);
                return Ok(asignacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
