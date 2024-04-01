using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar los productos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Api-Key")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoService;

        /// <summary>
        /// Constructor de la clase <see cref="ProductoController"/>.
        /// </summary>
        /// <param name="productoService">Servicio de producto.</param>
        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService ?? throw new ArgumentNullException(nameof(productoService));
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productoDto">Datos del producto a crear.</param>
        /// <returns>Una acción de resultado que representa el resultado de la operación.</returns>
        /// <response code="200">El producto ha sido creado correctamente.</response>
        /// <response code="400">La solicitud no es válida.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Producto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Producto>> CrearProducto([FromBody] Producto productoDto)
        {
            try
            {
                var producto = await _productoService.CreateAsync(productoDto);
                return Ok(producto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los productos.
        /// </summary>
        /// <returns>Una acción de resultado que representa el resultado de la operación.</returns>
        /// <response code="200">Se ha obtenido la lista de productos correctamente.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Producto>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerProductos()
        {
            try
            {
                var productos = await _productoService.GetProductosAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
