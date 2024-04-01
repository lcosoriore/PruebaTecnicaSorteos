using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para los clientes en el sistema de sorteos.
    /// </summary>
    public interface IClienteRepository
    {
        /// <summary>
        /// Obtiene una lista de todos los clientes en el sistema de sorteos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica de obtener clientes. Retorna una lista de objetos Cliente.</returns>
        Task<List<Cliente>> GetClientesAsync();
    }
}
