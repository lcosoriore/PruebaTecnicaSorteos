using Microsoft.AspNetCore.Mvc;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.API.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioService;

        /// <summary>
        /// Constructor de la clase <see cref="UsuarioController"/>.
        /// </summary>
        /// <param name="usuarioService">Servicio de usuario.</param>
        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        /// <summary>
        /// Obtiene una lista de usuarios asociados a un cliente.
        /// </summary>
        /// <param name="idCliente">Identificador del cliente.</param>
        /// <returns>Una acción de resultado que representa el resultado de la operación.</returns>
        /// <response code="200">Se ha obtenido la lista de usuarios correctamente.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios(int idCliente)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosAsync(idCliente);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
