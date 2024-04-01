using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para los productos en el sistema de sorteos.
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Crea un nuevo producto en el sistema de sorteos.
        /// </summary>
        /// <param name="producto">El producto que se va a crear.</param>
        /// <returns>Una tarea que representa la operación asincrónica de crear un producto. Retorna el producto creado.</returns>
        Task<Producto> CreateAsync(Producto producto);

        /// <summary>
        /// Obtiene una lista de todos los productos en el sistema de sorteos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica de obtener productos. Retorna una lista de objetos Producto.</returns>
        Task<List<Producto>> GetProductosAsync();
    }
}
