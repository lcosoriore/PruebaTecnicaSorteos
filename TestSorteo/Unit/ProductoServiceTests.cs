using Xunit;
using Moq;
using System.Threading.Tasks;
using Sorteo.Domain.Interfaces;
using Sorteo.Application.Services;
using Sorteo.Domain.Models;

namespace TestSorteo.Unit
{
    public class ProductoServiceTests
    {
        [Fact]
        public async Task CrearProductoAsync_DeberiaCrearProducto()
        {
            // Arrange
            var mockRepository = new Mock<IProductoRepository>();
            var productoService = new ProductoService(mockRepository.Object);
            var nombre = "Producto de prueba";
            var descripcion = "Descripción de producto de prueba";

            // Act
            await productoService.CrearProductoAsync(nombre, descripcion);

            // Assert
            mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<Producto>()), Times.Once);
        }

        [Fact]
        public async Task CrearProductoAsync_DeberiaRetornarProductoCreado()
        {
            // Arrange
            var mockRepository = new Mock<IProductoRepository>();
            var productoService = new ProductoService(mockRepository.Object);
            var nombre = "Producto de prueba";
            var descripcion = "Descripción de producto de prueba";
            var productoCreado = new Producto { Nombre = nombre, Descripcion = descripcion };
            mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Producto>())).ReturnsAsync(productoCreado);

            // Act
            var result = await productoService.CrearProductoAsync(nombre, descripcion);

            // Assert
            Assert.Equals(productoCreado, result);
        }
    }
}
