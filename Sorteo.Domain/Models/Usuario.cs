namespace Sorteo.Domain.Models
{
    /// <summary>
    /// Representa un usuario en el sistema de sorteos.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece el identificador único del usuario.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del cliente al que pertenece el usuario.
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del usuario.
        /// </summary>
        public string DescripcionUsuario { get; set; }
    }
}
