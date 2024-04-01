using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IClienteRepository"/> que proporciona operaciones de acceso a datos para los clientes en el contexto de la base de datos.
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClienteRepository"/>.
        /// </summary>
        /// <param name="configuration">La configuración de la aplicación.</param>
        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Obtiene la lista de clientes desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Cliente"/> representando los clientes.</returns>
        public async Task<List<Cliente>> GetClientesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT IdCliente, NombreCliente FROM Cliente";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var clientes = new List<Cliente>();

                    while (await reader.ReadAsync())
                    {
                        var cliente = new Cliente
                        {
                            IdCLiente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                            NombreCliente = reader.GetString(reader.GetOrdinal("NombreCliente"))
                        };

                        clientes.Add(cliente);
                    }

                    return clientes;
                }
            }
        }
    }
}
