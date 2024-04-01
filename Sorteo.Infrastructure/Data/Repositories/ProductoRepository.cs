using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IProductoRepository"/> que proporciona operaciones de acceso a datos para los productos en el contexto de la base de datos.
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoRepository"/>.
        /// </summary>
        /// <param name="configuration">La configuración de la aplicación.</param>
        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="producto">El producto a crear.</param>
        /// <returns>El producto creado con su ID asignado.</returns>
        public async Task<Producto> CreateAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Producto (Nombre, Descripcion) VALUES (@Nombre, @Descripcion); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);

                    var newProductId = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return new Producto
                    {
                        Id = newProductId,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion
                    };
                }
            }
        }

        /// <summary>
        /// Obtiene la lista de productos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Producto"/> representando los productos.</returns>
        public async Task<List<Producto>> GetProductosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, Nombre, Descripcion FROM Producto";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var productos = new List<Producto>();

                    while (await reader.ReadAsync())
                    {
                        var producto = new Producto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                        };

                        productos.Add(producto);
                    }

                    return productos;
                }
            }
        }
    }
}
