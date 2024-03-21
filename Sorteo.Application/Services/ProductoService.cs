using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;

namespace Sorteo.Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<Producto> CrearProductoAsync(string nombre, string descripcion)
        {
            var producto = new Producto { Nombre = nombre, Descripcion = descripcion };
            return await _productoRepository.CreateAsync(producto);
        }
    }
}
