using Sorteo.Domain.Models;
/// <summary>
/// Interfaz que define las operaciones de repositorio para las asignaciones en el sistema de sorteos.
/// </summary>
public interface IAsignacionRepository
{
    /// <summary>
    /// Crea una nueva asignación en el sistema de sorteos.
    /// </summary>
    /// <param name="asignacion">La asignación que se va a crear.</param>
    /// <returns>Una tarea que representa la operación asincrónica de creación. Retorna la asignación creada.</returns>
    Task<Asignacion> CreateAsync(Asignacion asignacion);

    /// <summary>
    /// Verifica si una asignación es válida en el sistema de sorteos.
    /// </summary>
    /// <param name="numeroAsignacion">El número de asignación a validar.</param>
    /// <param name="idCliente">El ID del cliente asociado a la asignación.</param>
    /// <param name="idUsuario">El ID del usuario asociado a la asignación.</param>
    /// <returns>Una tarea que representa la operación asincrónica de validación. Retorna true si la asignación es válida, de lo contrario, false.</returns>
    Task<bool> IsValidAsignacion(int numeroAsignacion, int idCliente, int idUsuario);
}
