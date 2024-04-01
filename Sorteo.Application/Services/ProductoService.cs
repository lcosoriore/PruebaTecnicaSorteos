using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de productos.
    /// </summary>
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        /// <summary>
        /// Constructor de la clase <see cref="ProductoService"/>.
        /// </summary>
        /// <param name="productoRepository">Repositorio de productos.</param>
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Crea un nuevo producto con el nombre y la descripción proporcionados.
        /// </summary>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="descripcion">Descripción del producto.</param>
        /// <returns>El producto creado.</returns>
        public async Task<Producto> CrearProductoAsync(string nombre, string descripcion)
        {
            var producto = new Producto { Nombre = nombre, Descripcion = descripcion };
            return await _productoRepository.CreateAsync(producto);
        }

        /// <summary>
        /// Obtiene una lista de todos los productos.
        /// </summary>
        /// <returns>Una lista de objetos Producto.</returns>
        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _productoRepository.GetProductosAsync();
        }
    }
}
