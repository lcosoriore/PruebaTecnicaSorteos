namespace Sorteo.Domain.Models
{
    /// <summary>
    /// Representa un cliente en el sistema de sorteos.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public int IdCLiente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string NombreCliente { get; set; }
    }
}
