using System.ComponentModel.DataAnnotations;

namespace Sorteo.Domain.Models
{
    /// <summary>
    /// Representa una asignación en el sistema de sorteos.
    /// </summary>
    public class Asignacion
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la asignación.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el número asignado para la asignación.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del cliente asociado a la asignación.
        /// </summary>
        [Required(ErrorMessage = "El ClienteId es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ClienteId debe ser mayor que cero.")]
        public int ClienteId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del usuario asociado a la asignación.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del producto asociado a la asignación.
        /// </summary>
        public int ProductoId { get; set; }
    }
}
