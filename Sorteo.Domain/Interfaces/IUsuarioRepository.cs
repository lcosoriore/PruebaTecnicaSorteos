using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Domain.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para los usuarios en el sistema de sorteos.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtiene una lista de usuarios asociados a un cliente específico en el sistema de sorteos.
        /// </summary>
        /// <param name="IdCliente">El identificador único del cliente para el cual se desean obtener los usuarios.</param>
        /// <returns>Una tarea que representa la operación asincrónica de obtener usuarios. Retorna una lista de objetos Usuario.</returns>
        Task<List<Usuario>> GetUsuariosAsync(int IdCliente);
    }
}
