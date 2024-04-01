using Microsoft.EntityFrameworkCore;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IUsuarioRepository"/> que proporciona operaciones de acceso a datos para los usuarios en el contexto de la base de datos.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioRepository"/>.
        /// </summary>
        /// <param name="context">El contexto de la aplicación.</param>
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de usuarios asociados a un cliente específico desde la base de datos.
        /// </summary>
        /// <param name="IdCliente">El ID del cliente.</param>
        /// <returns>Una lista de objetos <see cref="Usuario"/> representando los usuarios asociados al cliente especificado.</returns>
        public async Task<List<Usuario>> GetUsuariosAsync(int IdCliente)
        {
            // Consulta la base de datos para obtener los usuarios asociados al cliente especificado
            var usuarios = await _context.Usuario
                .Where(u => u.IdCliente == IdCliente)
                .ToListAsync();

            return usuarios;
        }
    }
}
