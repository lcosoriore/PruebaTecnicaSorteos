using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorteo.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de usuarios.
    /// </summary>
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor de la clase <see cref="UsuarioService"/>.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio de usuarios.</param>
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene una lista de usuarios asociados a un cliente específico.
        /// </summary>
        /// <param name="IdCliente">Identificador del cliente.</param>
        /// <returns>Una lista de objetos Usuario asociados al cliente especificado.</returns>
        public async Task<List<Usuario>> ObtenerUsuariosAsync(int IdCliente)
        {
            return await _usuarioRepository.GetUsuariosAsync(IdCliente);
        }
    }
}
