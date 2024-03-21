using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestSorteo.Integration
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CrearProducto_DeberiaRetornarOk()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/producto");
            request.Content = new StringContent("{\"nombre\":\"Producto de prueba\",\"descripcion\":\"Descripción de prueba\"}", System.Text.Encoding.UTF8, "application/json");

            // Agregar la autenticación de API Key al encabezado
            request.Headers.Add("ApiKey", "jPQ4tqcTNf8XwwCfLUrFn7CrmxGcanFWvXZG0JoU6Kn31GjZAjwnCc0Qzf0AqLMz");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equals("application/json", response.Content.Headers.ContentType.MediaType);
        }
    }
}
