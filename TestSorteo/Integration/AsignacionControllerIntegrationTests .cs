using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestSorteo.Integration
{
    public class AsignacionControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AsignacionControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AsignarNumero_DeberiaRetornarOk()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/asignacion");
            request.Content = new StringContent("{\"numero\":12345,\"clienteId\":1}", System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equals("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task AsignarNumero_ConDatosInvalidos_DeberiaRetornarBadRequest()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/asignacion");
            request.Content = new StringContent("{\"numero\":0,\"clienteId\":1}", System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equals(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

}
