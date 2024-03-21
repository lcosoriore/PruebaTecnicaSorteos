using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;


namespace Sorteo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Api-Key")]

    public class ProductoController : ControllerBase
    {
       
        private readonly IProductoRepository _productoService;

        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
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
    }
}
