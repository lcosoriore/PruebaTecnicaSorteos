using Microsoft.AspNetCore.Mvc;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar los clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteService;

        /// <summary>
        /// Constructor de la clase <see cref="ClienteController"/>.
        /// </summary>
        /// <param name="clienteService">Servicio de cliente.</param>
        public ClienteController(IClienteRepository clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una acción de resultado que representa el resultado de la operación.</returns>
        /// <response code="200">Se ha obtenido la lista de clientes correctamente.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerClientes()
        {
            try
            {
                var clientes = await _clienteService.GetClientesAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
