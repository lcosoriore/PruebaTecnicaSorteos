using Microsoft.EntityFrameworkCore;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IAsignacionRepository"/> que proporciona operaciones de acceso a datos para las asignaciones en el contexto de la base de datos.
    /// </summary>
    public class AsignacionRepository : IAsignacionRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AsignacionRepository"/>.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public AsignacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea una nueva asignación en la base de datos.
        /// </summary>
        /// <param name="asignacion">La asignación a crear.</param>
        /// <returns>La asignación creada.</returns>
        public async Task<Asignacion> CreateAsync(Asignacion asignacion)
        {
            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();
            return asignacion;
        }

        /// <summary>
        /// Verifica si una asignación válida ya existe en la base de datos.
        /// </summary>
        /// <param name="numeroAsignacion">El número de asignación a verificar.</param>
        /// <param name="idCliente">El ID del cliente asociado a la asignación.</param>
        /// <param name="idUsuario">El ID del usuario asociado a la asignación.</param>
        /// <returns>True si la asignación es válida, False si no.</returns>
        public async Task<bool> IsValidAsignacion(int numeroAsignacion, int idCliente, int idUsuario)
        {
            return await _context.Asignaciones.AnyAsync(k => k.Numero == numeroAsignacion && k.ClienteId == idCliente && k.UsuarioId == idUsuario);
        }
    }
}
