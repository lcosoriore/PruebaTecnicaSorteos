using Moq;
using Sorteo.Application.Services;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestSorteo.Unit
{
    public class AsignacionServiceTests
    {
        [Fact]
        public async Task AsignarNumeroAsync_DeberiaAsignarNumero()
        {
            // Arrange
            var mockRepository = new Mock<IAsignacionRepository>();
            var asignacionService = new AsignacionService(mockRepository.Object);
            var clienteId = 1;

            // Act
            await asignacionService.AsignarNumeroAsync(clienteId);

            // Assert
            mockRepository.Verify(repo => repo.CreateAsync(It.IsAny<Asignacion>()), Times.Once);
        }

        [Fact]
        public async Task AsignarNumeroAsync_DeberiaGenerarNumeroAleatorio()
        {
            // Arrange
            var mockRepository = new Mock<IAsignacionRepository>();
            var asignacionService = new AsignacionService(mockRepository.Object);
            var clienteId = 1;

            // Act
            await asignacionService.AsignarNumeroAsync(clienteId);

            // Assert
            mockRepository.Verify(repo => repo.CreateAsync(It.Is<Asignacion>(a => a.Numero >= 10000 && a.Numero <= 99999)), Times.Once);
        }

        [Fact]
        public async Task AsignarNumeroAsync_DeberiaValidarNumero()
        {
            // Arrange
            var mockRepository = new Mock<IAsignacionRepository>();
            var asignacionService = new AsignacionService(mockRepository.Object);
            var clienteId = 1;

            // Act
            await asignacionService.AsignarNumeroAsync(clienteId);

        }

        
    }
}
